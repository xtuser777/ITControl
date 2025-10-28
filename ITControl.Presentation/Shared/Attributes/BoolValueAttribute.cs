using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class BoolValueAttribute : ValidationAttribute
{
    public BoolValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.INVALID_BOOLEAN);
    }
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        return value is null or bool 
            ? ValidationResult.Success 
            : new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName));
    }
}
