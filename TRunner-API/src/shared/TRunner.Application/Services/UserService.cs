using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TRunner.Application.Commands.UserCommands;
using TRunner.Application.Interfaces.MinIO;
using TRunner.Application.Queries.UserQueries;
using TRunner.Application.Services.Interfaces;
using TRunner.Core;
using TRunner.Core.Common.Exceptions;
using TRunner.Core.Resources;
using TRunner.Domain.Entities;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services;

public class UserService : IUserService
{
    #region Private Members
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IAuthenticateService _authenticateService;
    private readonly IMinIOService _minIOService;
    #endregion

    #region Constructors
    public UserService(IMapper mapper, IMediator mediator, IAuthenticateService authenticateService, IMinIOService minIOService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _authenticateService = authenticateService;
        _minIOService = minIOService;
    }
    #endregion

    #region
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request, string ipAddress)
    {
        var user = (await _mediator.Send(new FindBy.Query(
            x => x.IsActive == true && x.IsDeleted == false && x.Email == request.Email && x.IsRunner == (request.IsRunner ? 1 : 0))))
                .Include(x => x.UserRole)
                .Include(x => x.RefreshTokens)
                .FirstOrDefault();

        // return null if user not found
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new KnownAPIException(Resources.User_Login_Wrong_Username_Password, (int)HttpStatusCode.BadRequest);
        }

        // authentication successful so generate jwt and refresh tokens
        var jwtToken = _authenticateService.GenerateJwtToken(user);
        var refreshToken = await _authenticateService.GenerateRefreshToken(ipAddress);
        user.RefreshTokens.Add(refreshToken);

        _authenticateService.RemoveOldRefreshTokens(user);

        var result = await _mediator.Send(new UpdateUser.Command(user));
        if (result <= 0)
        {
            throw new KnownAPIException(Resources.User_Update_Failed, (int)HttpStatusCode.InternalServerError);
        }

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = jwtToken;
        response.RefreshToken = refreshToken.Token;

        return response;
    }

    public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
    {
        var user = await GetUserByRefreshToken(token);

        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (refreshToken.IsRevoked)
        {
            // revoke all descendant tokens in case this token has been compromised
            RevokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
            await _mediator.Send(new UpdateUser.Command(user));
        }

        if (!refreshToken.IsTokenActive)
        {
            throw new KnownAPIException(Resources.User_RefreshToken_Invalid, (int)HttpStatusCode.InternalServerError);
        }

        // replace old refresh token with a new one (rotate token)
        var newRefreshToken = await _authenticateService.GenerateRefreshToken(ipAddress);
        RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);

        user.RefreshTokens.Add(newRefreshToken);

        // remove old refresh tokens from user
        _authenticateService.RemoveOldRefreshTokens(user);

        // save changes to db
        await _mediator.Send(new UpdateUser.Command(user));

        // generate new jwt
        var jwtToken = _authenticateService.GenerateJwtToken(user);

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = jwtToken;
        response.RefreshToken = newRefreshToken.Token;

        return response;
    }

    public async Task RevokeToken(string token, string ipAddress)
    {
        var user = await GetUserByRefreshToken(token);
        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (!refreshToken.IsTokenActive)
        {
            throw new KnownAPIException(Resources.User_RefreshToken_Invalid, (int)HttpStatusCode.InternalServerError);
        }

        // revoke token and save
        RevokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
        await _mediator.Send(new UpdateUser.Command(user));
    }

    public async Task<TRunnerPageResults<UserResponse>> GetAll(PaginationRequest request)
    {
        var users = await _mediator.Send(new GetUsers.Query(request));
        return users;
    }

    public async Task<UserResponse> GetById(int userId)
    {
        if (userId <= 0)
        {
            throw new KnownAPIException(Resources.User_GetById, (int)HttpStatusCode.BadRequest);
        }

        var user = (await _mediator.Send(new FindBy.Query(x => x.UserId == userId)))
            .Include(x => x.UserRole)
            .FirstOrDefault();

        if (user == null)
        {
            throw new KnownAPIException(Resources.User_Notfound, (int)HttpStatusCode.NotFound);
        }

        return _mapper.Map<UserResponse>(user);
    }

    public async Task Register(RegisterRequest request)
    {
        var userRole = (await _mediator.Send(
            new Queries.UserRoleQueries.FindBy.Query(x => x.RoleName == "Runner")))
            .FirstOrDefault();
        if (userRole == null)
        {
            throw new KnownAPIException(Resources.User_Register_UserRole_NotFound, (int)HttpStatusCode.NotFound);
        }

        var existedUser = (await _mediator.Send(
            new FindBy.Query(x => x.Email == request.Email && x.UserRoleId == userRole.UserRoleId)))
            .FirstOrDefault();
        if (existedUser != null)
        {
            throw new KnownAPIException(Resources.User_Register_Duplicate, (int)HttpStatusCode.Conflict);
        }

        var createdUser = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            IsRunner = 1,
            UserRoleId = userRole.UserRoleId
        };

        var result = await _mediator.Send(new CreateUser.Command(createdUser));

        if (result <= 0)
        {
            throw new KnownAPIException(Resources.User_Register_Create_User_Failed, (int)HttpStatusCode.InternalServerError);
        }
    }

    public async Task UpdateUser(UpdateUserRequest request)
    {
        var curUser = (await _mediator.Send(new FindBy.Query(x => x.UserId == request.UserId)))
            .FirstOrDefault();
        if (curUser == null)
        {
            throw new KnownAPIException(Resources.User_Notfound, (int)HttpStatusCode.NotFound);
        }

        _mapper.Map(request, curUser);

        // Add and remove image for user
        if (request.Image != null)
        {
            if (!string.IsNullOrEmpty(curUser.ImageUrl))
            {
                await _minIOService.RemoveImages(new List<string> { curUser.ImageUrl });
            }

            var imageUrls = await _minIOService.UploadImages(new List<ImageInfo> { request.Image }, Constants.ContainerFolder.Users);
            if (imageUrls.Count > 0)
            {
                curUser.ImageUrl = imageUrls.FirstOrDefault();
            }
        }

        var result = await _mediator.Send(new UpdateUser.Command(curUser));
        if (result <= 0)
        {
            throw new KnownAPIException(Resources.User_Update_Failed, (int)HttpStatusCode.InternalServerError);
        }
    }
    #endregion

    #region Private methods
    private async Task<User> GetUserByRefreshToken(string token)
    {
        var user = (await _mediator.Send(new FindBy.Query(x => x.RefreshTokens.Any(y => y.Token == token))))
            .Include(x => x.RefreshTokens)
            .FirstOrDefault();
        if (user == null)
        {
            throw new KnownAPIException(Resources.User_Notfound, (int)HttpStatusCode.NotFound);
        }

        return user;
    }

    private void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
    {
        // recursively traverse the refresh token chain and ensure all descendants are revoked
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
            if (childToken.IsTokenActive)
            {
                RevokeRefreshToken(childToken, ipAddress, reason);
            }
            else
            {
                RevokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }
    }

    private void RevokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;
        token.ReasonRevoked = reason;
        token.ReplacedByToken = replacedByToken;
    }
    #endregion
}
