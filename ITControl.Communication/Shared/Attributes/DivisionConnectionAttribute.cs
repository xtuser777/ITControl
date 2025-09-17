using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class DivisionConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid divisionId || divisionId == Guid.Empty)
            return ValidationResult.Success;
        var divisionsRepository = (IDivisionsRepository)validationContext.GetService(typeof(IDivisionsRepository))!;
        var exists = divisionsRepository.ExistsAsync(id: divisionId).Result;
        if (!exists)
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, divisionId));

        return ValidationResult.Success;
    }
}
