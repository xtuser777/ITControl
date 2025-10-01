using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class UpdateDivisionsRequest
{
    [StringMaxLength(100)]
    [CustomValidation(typeof(UpdateDivisionsRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    public static ValidationResult? ValidateName(string? name, ValidationContext context)
    {
        if (string.IsNullOrEmpty(name))
        {
            return ValidationResult.Success;
        }
        var divisionsRepository = (context.
            GetService(typeof(IDivisionsRepository)) as IDivisionsRepository)!;
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext 
            ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = divisionsRepository
            .ExclusiveAsync(new() { Id = id, Name = name })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(Errors.UniqueField, context.DisplayName));
        }

        return ValidationResult.Success;
    }

    public static implicit operator UpdateDivisionParams(UpdateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}