using Microsoft.AspNetCore.Mvc;
using TRunner.Application.Middleware.JwtAuthorization;
using TRunner.Application.Services.Interfaces;
using TRunner.Core.Resources;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner_API.Controllers;

[Authorize]
[ApiController]
[Route("v{version:apiVersion}")]
[ApiVersion("1")]
public class UserController : ControllerBase
{
    #region Private Members
    private readonly IUserService _userService;
    #endregion

    #region Constructors
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region
    [HttpGet("profile/{id}")]
    public async Task<IActionResult> GetUserProfile(int id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.Register(request);
        var authenResponse = await _userService.Authenticate(new AuthenticateRequest
        {
            Email = request.Email,
            Password = request.Password,
        }, GetIpAddress());
        SetTokenCookie(authenResponse);

        return Created("/register", authenResponse);
    }

    [HttpPut("profile/{id}")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {
        await _userService.UpdateUser(request);

        return NoContent();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request, GetIpAddress());
        SetTokenCookie(response);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshToken(refreshToken, GetIpAddress());
        SetTokenCookie(response);
        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> RevokeToken()
    {
        // accept refresh refreshToken in request body or cookie
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return BadRequest(new { message = Resources.User_RevokeToken_Token_Required });

        await _userService.RevokeToken(refreshToken, GetIpAddress());
        RemoveCookie();

        return Ok(Resources.User_RevokeToken_Success);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var users = await _userService.GetAll(request);
        return Ok(users);
    }
    #endregion

    #region Private methods
    private void SetTokenCookie(AuthenticateResponse tokenInfo)
    {
        // append cookie with token and refreshToken to the http response
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };

        Response.Cookies.Append("token", tokenInfo.Token, cookieOptions);
        Response.Cookies.Append("refreshToken", tokenInfo.RefreshToken, cookieOptions);
    }
    private void RemoveCookie()
    {
        Response.Cookies.Delete("token");
        Response.Cookies.Delete("refreshToken");
    }

    private string GetIpAddress()
    {
        // get source ip address for the current request
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
    #endregion
}
