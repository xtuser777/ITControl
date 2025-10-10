using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

public class CreateDepartmentsRequest
{
    [RequiredField]
    [StringMaxLength(10)]
    [CustomValidation(typeof(CreateDepartmentsRequest), nameof(ValidateAlias))]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string Alias { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [CustomValidation(typeof(CreateDepartmentsRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    public static ValidationResult? ValidateAlias(string alias, ValidationContext context)
    {
        if (string.IsNullOrEmpty(alias))
        {
            return ValidationResult.Success;
        }
        var departmentsRepository = 
            (context.GetService(typeof(IDepartmentsRepository)) as IDepartmentsRepository)!;
        var exists = departmentsRepository
            .ExistsAsync(new() { Alias = alias })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(Errors.UniqueField, context.DisplayName));    
        }
        
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateName(string name, ValidationContext context)
    {
        if (string.IsNullOrEmpty(name))
        {
            return ValidationResult.Success;
        }
        var departmentsRepository =
            (context.GetService(typeof(IDepartmentsRepository)) as IDepartmentsRepository)!;
        var exists = departmentsRepository
            .ExistsAsync(new() { Name = name })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(Errors.UniqueField, context.DisplayName));
        }

        return ValidationResult.Success;
    }

    public static implicit operator DepartmentParams(CreateDepartmentsRequest request) =>
        new()
        {
            Alias = request.Alias,
            Name = request.Name
        };
}