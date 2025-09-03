using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class TimePresentPastAttribute : ValidationAttribute
{
    public TimePresentPastAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = "TIME_PRESENT_PAST";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Consider null as valid. Use [Required] for null checks.
        }
        if (value is TimeOnly time)
        {
            var now = TimeOnly.FromDateTime(DateTime.Now);
            if (time > now)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage ?? "O campo não é uma hora válida.");
    }
}
