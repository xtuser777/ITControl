using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class TimeGreaterThanCurrentAttribute : ValidationAttribute
{
    private readonly string date;

    public TimeGreaterThanCurrentAttribute(string date)
    {
        this.date = date;
        ErrorMessageResourceType = typeof(Domain.Shared.Messages.Errors);
        ErrorMessageResourceName = "TIME_GREATER_THAN_CURRENT";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(date) 
            ?? throw new ArgumentException("Comparison property not found.");
        var comparisonValue = (DateOnly?)property.GetValue(validationContext.ObjectInstance);
        
        var currentValue = (TimeOnly)(value ?? throw new ArgumentNullException(nameof(value)));

        if (
            currentValue < TimeOnly.FromDateTime(DateTime.Now) 
            && comparisonValue == DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }
}
