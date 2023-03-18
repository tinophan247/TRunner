using TRunner.Domain.Entities;

namespace TRunner.Application.Services.Interfaces;

public interface IAuthenticateService
{
    string GenerateJwtToken(User user);
    int ValidateJwtToken(string token);
    Task<RefreshToken> GenerateRefreshToken(string ipAddress);
    void RemoveOldRefreshTokens(User user);
}
