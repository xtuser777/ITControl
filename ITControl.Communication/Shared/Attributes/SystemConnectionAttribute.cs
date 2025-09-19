using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Systems.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class SystemConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid systemId || systemId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var systemsRepository = (ISystemsRepository)validationContext.GetService(typeof(ISystemsRepository))!;
        bool systemExists = systemsRepository.ExistsAsync(id: systemId).GetAwaiter().GetResult();
        if (!systemExists)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, systemId));
        }
        return ValidationResult.Success;
    }
}
