using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Domain.Systems.Params;

namespace ITControl.Communication.Shared.Attributes;

public class SystemConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid systemId || systemId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var systemsRepository = 
            (ISystemsRepository)validationContext
                .GetService(typeof(ISystemsRepository))!;
        var existsParams = new ExistsSystemsParams { Id = systemId };
        var systemExists = systemsRepository
            .ExistsAsync(existsParams).GetAwaiter().GetResult();
        return !systemExists 
            ? new ValidationResult(string.Format(
                Errors.ConnectionNotFound, validationContext.DisplayName, systemId)) 
            : ValidationResult.Success;
    }
}
