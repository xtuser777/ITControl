using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Units.Interfaces;
using ITControl.Domain.Units.Params;

namespace ITControl.Presentation.Shared.Attributes;

public class UnitConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid unitId || unitId == Guid.Empty)
            return ValidationResult.Success;
        var unitsRepository = 
            (IUnitsRepository)validationContext
                .GetService(typeof(IUnitsRepository))!;
        var existsParams = new ExistsUnitsParams { Id = unitId };
        var exists = unitsRepository
            .ExistsAsync(existsParams).GetAwaiter().GetResult();
        if (!exists)
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, validationContext.DisplayName, unitId));

        return ValidationResult.Success;
    }
}
