using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ITControl.Communication.Shared.Attributes;

public class TimeGreaterThanCurrentAttribute(string scheduledAt) : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(scheduledAt);
        if (property == null)
        {
            throw new ArgumentException("Comparison property not found.");
        }

        var comparisonValue = (DateOnly?)property.GetValue(validationContext.ObjectInstance);
        
        var currentValue = (TimeOnly)(value ?? throw new ArgumentNullException(nameof(value)));

        if (
            currentValue < TimeOnly.FromDateTime(DateTime.Now) 
            && comparisonValue == DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(
                ErrorMessage = ErrorMessage 
                ?? $"{validationContext.DisplayName} must be greater than current.");
        }

        return ValidationResult.Success ?? throw new NullReferenceException();
    }
}
