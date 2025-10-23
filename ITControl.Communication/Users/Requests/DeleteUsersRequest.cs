using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ITControl.Communication.Users.Requests;

public class DeleteUsersRequest
{
    [RequiredField]
    [GuidValue]
    [Display(Name = nameof(LoggedUserId), ResourceType = typeof(DisplayNames))]
    public Guid LoggedUserId { get; set; }

    public static ValidationResult? ValidateLoggedUserId(
        Guid? loggedUserId, ValidationContext context)
    {
        if (loggedUserId is null || loggedUserId == Guid.Empty) 
            return null;
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext 
                          ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        return loggedUserId.Value.ToString() == idRoute 
            ? new ValidationResult(
                string.Format(Errors.DontRemoveYourself)) 
            : ValidationResult.Success;
    }
}