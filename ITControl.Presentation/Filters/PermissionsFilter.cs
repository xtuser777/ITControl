using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITControl.Presentation.Filters;

[AttributeUsage(AttributeTargets.All)]
public class PermissionsFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"]?.ToString() ?? "";
        context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorization);
        var tokenString = authorization.ToString().Split(' ')[1];
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenString);
        var permissionsRaw = token.Payload["permissions"];
        if (permissionsRaw == null)
            throw new UnauthorizedAccessException();
        List<string> permissionsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>((string)permissionsRaw) ?? throw new InvalidOperationException();
        var pass = permissionsJson.Contains(controller.ToLower());
        if (!pass)
            throw new UnauthorizedAccessException();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // throw new NotImplementedException();
    }
}