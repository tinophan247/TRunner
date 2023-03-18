using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TRunner.Core.Common.Exceptions;
using TRunner.Core.Resources;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Middleware.JwtAuthorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            return;
        }    

        var user = (UserResponse)context.HttpContext.Items["User"];
        // TODO: user đúng role chưa...
        if (user == null)
        {
            throw new KnownAPIException(Resources.Unauthorized, (int)HttpStatusCode.Unauthorized);
        }
    }
}
