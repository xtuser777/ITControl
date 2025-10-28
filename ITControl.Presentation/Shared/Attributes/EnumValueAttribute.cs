using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class EnumValueAttribute : ValidationAttribute
{
    private readonly Type _enumType;
    private string _enumValues = "";

    public EnumValueAttribute(Type enumType)
    {
        _enumType = enumType;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MustBeAOneOfTheseValues);
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(Errors.MustBeAOneOfTheseValues, name, _enumValues);
    }

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;
        var allowedValues = Enum.GetNames(_enumType);
        if (allowedValues.Contains(value)) return ValidationResult.Success;
        _enumValues = string.Join(",", allowedValues);
        return new ValidationResult(
            FormatErrorMessage(validationContext.DisplayName));
    }
}