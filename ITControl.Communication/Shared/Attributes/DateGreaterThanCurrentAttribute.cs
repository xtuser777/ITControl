using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ITControl.Communication.Shared.Attributes;

public class DateGreaterThanCurrentAttribute() : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var currentValue = (DateOnly)(value ?? throw new ArgumentNullException(nameof(value)));

        if (currentValue < DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(
                ErrorMessage = ErrorMessage 
                ?? $"{validationContext.DisplayName} must be greater than current.");
        }

        return ValidationResult.Success ?? throw new NullReferenceException();
    }
}
