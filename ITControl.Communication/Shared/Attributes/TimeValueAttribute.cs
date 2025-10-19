using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Attributes;

public class TimeValueAttribute : ValidationAttribute
{
    public TimeValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.INVALID_TIME);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        if (value is TimeOnly time)
        {
            if (time == TimeOnly.MinValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
