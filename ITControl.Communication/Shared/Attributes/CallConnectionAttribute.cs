using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class CallConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid callId || callId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var callsRepository = (ICallsRepository)validationContext.GetService(typeof(ICallsRepository))!;
        bool callExists = callsRepository.ExistsAsync(id: callId).Result;
        if (!callExists)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, callId));
        }

        return ValidationResult.Success;
    }
}
