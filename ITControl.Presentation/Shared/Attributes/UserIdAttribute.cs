using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;

namespace ITControl.Presentation.Shared.Attributes;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class UserIdAttribute : Attribute, IBindingSourceMetadata, IModelBinder
{
    public BindingSource? BindingSource => BindingSource.Custom;

    public Task BindModelAsync(ModelBindingContext context)
    {
        context.HttpContext.Request.Headers
                .TryGetValue("Authorization", out var authorization);
        if (authorization.ToString().Split(' ').Length > 1)
        {
            var tokenString = authorization.ToString().Split(' ')[1];
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);
            var sub = (string)token.Payload["sub"];
            Guid.TryParse(sub, out var userId);
            var value = userId;
            context.Result = ModelBindingResult.Success(value);
            return Task.CompletedTask;
        }
        context.Result = ModelBindingResult.Failed();
        return Task.CompletedTask;
    }
}
