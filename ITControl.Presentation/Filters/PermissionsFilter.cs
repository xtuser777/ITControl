using System.IdentityModel.Tokens.Jwt;
using System.Net;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITControl.Presentation.Filters;

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
            var permissionsRaw = token.Payload["permissions"];
            if (permissionsRaw == null)
                throw new UnauthorizedAccessException();
            var permissionsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>((string)permissionsRaw) ?? throw new InvalidOperationException();
            var pass = permissionsJson.Contains(controller.ToLower());
            if (!pass)
                throw new UnauthorizedAccessException();
        }
        catch (UnauthorizedAccessException exception)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new UnauthorizedObjectResult(new ErrorJsonResponse(exception.Message));
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // throw new NotImplementedException();
    }
}