using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [CustomValidation(typeof(CreateDivisionsRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid DepartmentId { get; set; }

    public static ValidationResult? ValidateName(string name, ValidationContext context)
    {         
        if (string.IsNullOrEmpty(name))
        {
            return ValidationResult.Success;
        }
        var divisionsRepository = (context.GetService(typeof(IDivisionsRepository)) as IDivisionsRepository)!;
        var exists = divisionsRepository.ExistsAsync(new() { Name = name }).GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.UniqueField, context.DisplayName));
        }

        return ValidationResult.Success;
    }

    public static implicit operator DivisionParams(CreateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}