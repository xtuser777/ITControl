using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class DatePresentPastAttribute : ValidationAttribute
{
    public DatePresentPastAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.DATE_PRESENT_PAST);
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Consider null as valid, use [Required] for null checks
        }
        var currentValue = (DateOnly)(value ?? throw new ArgumentNullException(nameof(value)));
        if (currentValue != DateOnly.MinValue && currentValue > DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}
