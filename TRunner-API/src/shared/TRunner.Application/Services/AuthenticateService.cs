using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TRunner.Application.Services.Interfaces;
using TRunner.Domain.Entities;
using TRunner.Domain.Models.Options;

namespace TRunner.Application.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly JwtOptions _jwtOptions;
    private readonly IMediator _mediator;

    public AuthenticateService(IOptions<JwtOptions> jwtOptions, IMediator mediator)
    {
        _jwtOptions = jwtOptions.Value;
        _mediator = mediator;
    }

    public string GenerateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.DisplayName ?? string.Empty),
                new Claim("role", user.UserRole.RoleName),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int ValidateJwtToken(string token)
    {
        if (token == null)
            return -1;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return -1;
        }
    }

    public async Task<RefreshToken> GenerateRefreshToken(string ipAddress)
    {

        var refreshToken = new RefreshToken
        {
            Token = await getUniqueToken(),
            // token is valid for 3 month
            Expires = DateTime.UtcNow.AddMonths(3),
            CreatedByIp = ipAddress,
        };

        return refreshToken;

        async Task<string> getUniqueToken()
        {
            // token is a cryptographically strong random sequence of values
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            // ensure token is unique by checking against db
            var user = (await _mediator.Send(new Queries.UserQueries.FindBy.Query(x => x.RefreshTokens.Any(t => t.Token == token)))).FirstOrDefault();           
            if (user != null)
                return await getUniqueToken();

            return token;
        }
    }

    public void RemoveOldRefreshTokens(User user)
    {
        foreach (var refreshToken in user.RefreshTokens)
        {
            if (!refreshToken.IsTokenActive && refreshToken.CreatedDate.AddDays(2) <= DateTime.UtcNow)
            {
                user.RefreshTokens.Remove(refreshToken);
            }
        }
    }
}
