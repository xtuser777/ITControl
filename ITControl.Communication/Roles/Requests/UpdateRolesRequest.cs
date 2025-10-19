using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ITControl.Communication.Roles.Requests;

public record UpdateRolesRequest
{
    [StringMaxLength(100)]
    [CustomValidation(typeof(UpdateRolesRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [BoolValue]
    [Display(Name = nameof(Active), ResourceType = typeof(DisplayNames))]
    public bool? Active { get; set; }
    
    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }

    public static implicit operator UpdateRoleParams(UpdateRolesRequest request) => new()
    {
        Name = request.Name,
        Active = request.Active
    };

    public static ValidationResult? ValidateName(string name, ValidationContext context)
    {
        var rolesRepository =
            (IRolesRepository?)context.GetService(typeof(IRolesRepository))!;
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        var _ = Guid.TryParse(idRoute, out Guid id);
        var exclusive = rolesRepository
            .ExclusiveAsync(new ExclusiveRolesRepositoryParams { Id = id, Name = name })
            .GetAwaiter()
            .GetResult();
        if (exclusive)
            return new ValidationResult(string.Format(Errors.UniqueField, DisplayNames.Name));
        return ValidationResult.Success;
    }
}