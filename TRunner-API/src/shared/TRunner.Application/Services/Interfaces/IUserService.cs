using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request, string ipAddress);
    Task<TRunnerPageResults<UserResponse>> GetAll(PaginationRequest request);
    Task<UserResponse> GetById(int userId);
    Task Register(RegisterRequest request);
    Task UpdateUser(UpdateUserRequest request);
    Task<AuthenticateResponse> RefreshToken(string token, string ipAddress);
    Task RevokeToken(string token, string ipAddress);
}
