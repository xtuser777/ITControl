using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class BoolValueAttribute : ValidationAttribute
{
    public BoolValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.INVALID_BOOLEAN);
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null or bool)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
