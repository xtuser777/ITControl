using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Attributes;

public class DateGreatherThanAttribute : ValidationAttribute
{
    private readonly string _dateGreatherThan;

    public DateGreatherThanAttribute(string dateGreatherThan)
    {
        _dateGreatherThan = dateGreatherThan;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.DATE_GREATER_THAN);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly dateValue && dateValue != DateOnly.MinValue)
        {
            var comparisonProperty = validationContext.ObjectType.GetProperty(_dateGreatherThan);
            if (comparisonProperty != null) 
            {
                var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance);
                if (comparisonValue is DateOnly comparisonDateValue && comparisonDateValue != DateOnly.MinValue)
                {
                    if (dateValue > comparisonDateValue)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
        }
        return ValidationResult.Success;
    }
}
