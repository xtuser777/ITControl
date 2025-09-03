using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class DatePresentPastAttribute : ValidationAttribute
{
    public DatePresentPastAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = "DATE_PRESENT_PAST";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Consider null as valid, use [Required] for null checks
        }
        var currentValue = (DateOnly)(value ?? throw new ArgumentNullException(nameof(value)));
        if (currentValue > DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}
