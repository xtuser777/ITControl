using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ITControl.Communication.Shared.Attributes;

public class DateGreaterThanCurrentAttribute(string comparisonProperty) : ValidationAttribute
{
    private readonly string _comparisonProperty = comparisonProperty;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var currentValue = (DateOnly)value;

        if (currentValue < DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(
                ErrorMessage = ErrorMessage 
                ?? $"{validationContext.DisplayName} must be greater than current.");
        }

        return ValidationResult.Success ?? throw new NullReferenceException();
    }
}
