using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Attributes;

public class DateValueAttribute : ValidationAttribute
{
    public DateValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.INVALID_DATE);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        if (value is DateOnly date)
        {
            if (date == DateOnly.MinValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
