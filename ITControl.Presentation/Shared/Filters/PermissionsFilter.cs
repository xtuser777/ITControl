using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace ITControl.Presentation.Shared.Filters;

[AttributeUsage(AttributeTargets.All)]
public class PermissionsFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        try
        {
            var controller = context.RouteData.Values["controller"]?.ToString() ?? "";
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorization);
            var tokenString = authorization.ToString().Split(' ')[1];
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);
            var permissionsRaw = token.Payload["permissions"] ?? throw new UnauthorizedAccessException();
            var permissionsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>((string)permissionsRaw) ?? throw new InvalidOperationException();
            var pass = permissionsJson.Contains(controller.ToLower());
            if (!pass)
                throw new UnauthorizedAccessException();
        }
        catch (UnauthorizedAccessException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        
    }
}