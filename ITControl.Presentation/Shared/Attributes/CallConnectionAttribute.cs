using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class CallConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid callId || callId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var callsRepository = 
            (ICallsRepository)validationContext
                .GetService(typeof(ICallsRepository))!;
        bool callExists = callsRepository
            .ExistsAsync(new ExistsCallsParams { Id = callId })
            .GetAwaiter().GetResult();
        if (!callExists)
        {
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, 
                    validationContext.DisplayName, callId));
        }

        return ValidationResult.Success;
    }
}
