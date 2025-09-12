using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class TimePresentPastAttribute : ValidationAttribute
{
    public TimePresentPastAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.TimePresentPast);
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Consider null as valid. Use [Required] for null checks.
        }
        if (value is TimeOnly time)
        {
            if (time == TimeOnly.MinValue)
            {
                return ValidationResult.Success;
            }
            var now = TimeOnly.FromDateTime(DateTime.Now);
            if (time > now)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(Errors.INVALID_TIME);
    }
}
