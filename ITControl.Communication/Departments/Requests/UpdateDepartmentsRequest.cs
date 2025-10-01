using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Shared.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    [StringMaxLength(10)]
    [CustomValidation(typeof(UpdateDepartmentsRequest), nameof(ValidateAlias))]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string? Alias { get; set; }
    
    [StringMaxLength(100)]
    [CustomValidation(typeof(UpdateDepartmentsRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    public static ValidationResult? ValidateAlias(string? alias, ValidationContext context)
    {
        if (string.IsNullOrEmpty(alias))
        {
            return ValidationResult.Success;
        }
        var departmentsRepository =
            (context.GetService(typeof(IDepartmentsRepository)) as IDepartmentsRepository)!;
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = departmentsRepository
            .ExclusiveAsync(new() { Id = id, Alias = alias })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(Errors.UniqueField, context.DisplayName));
        }

        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateName(string? name, ValidationContext context)
    {
        if (string.IsNullOrEmpty(name))
        {
            return ValidationResult.Success;
        }
        var departmentsRepository =
            (context.GetService(typeof(IDepartmentsRepository)) as IDepartmentsRepository)!;
        var httpContextAccessor = context.
            GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var httpContext = httpContextAccessor?.HttpContext ?? throw new NullReferenceException();
        var idRoute = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
        Guid.TryParse(idRoute, out Guid id);
        var exists = departmentsRepository
            .ExclusiveAsync(new() { Id = id, Name = name })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(Errors.UniqueField, context.DisplayName));
        }

        return ValidationResult.Success;
    }

    public static implicit operator UpdateDepartmentParams(UpdateDepartmentsRequest request)
    {
        return new UpdateDepartmentParams
        {
            Alias = request.Alias,
            Name = request.Name
        };
    }
}