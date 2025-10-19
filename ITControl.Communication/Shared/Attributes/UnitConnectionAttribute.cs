using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Units.Interfaces;

namespace ITControl.Communication.Shared.Attributes;

public class UnitConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid unitId || unitId == Guid.Empty)
            return ValidationResult.Success;
        var unitsRepository = (IUnitsRepository)validationContext.GetService(typeof(IUnitsRepository))!;
        var exists = unitsRepository.ExistsAsync(new() { Id = unitId }).GetAwaiter().GetResult();
        if (!exists)
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, unitId));

        return ValidationResult.Success;
    }
}
