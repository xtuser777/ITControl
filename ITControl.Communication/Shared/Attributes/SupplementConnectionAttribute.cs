using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Supplements.Interfaces;

namespace ITControl.Communication.Shared.Attributes;

public class SupplementConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid supplementId || supplementId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var supplementRepository = (ISupplementsRepository)validationContext.GetService(typeof(ISupplementsRepository))!;
        var exists = supplementRepository.ExistsAsync(id: supplementId).GetAwaiter().GetResult();
        if (exists == false)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, supplementId));
        }

        return ValidationResult.Success;
    }
}
