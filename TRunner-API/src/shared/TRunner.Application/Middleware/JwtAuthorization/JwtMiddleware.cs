using Microsoft.AspNetCore.Http;
using TRunner.Application.Services.Interfaces;

namespace TRunner.Application.Middleware.JwtAuthorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthenticateService _authenticateService;

    public JwtMiddleware(RequestDelegate next, IAuthenticateService authenticateService)
    {
        _next = next;
        _authenticateService = authenticateService;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {

        var token = context.Request.Cookies["token"];
        if (string.IsNullOrEmpty(token))
        {
            token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? string.Empty;
        }

        var userId = _authenticateService.ValidateJwtToken(token);

        if (userId > 0)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = await userService.GetById(userId);
        }

        await _next(context);
    }
}
