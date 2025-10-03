using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ITControl.Communication.Shared.Attributes;

public class DocumentValueAttribute : ValidationAttribute
{
    public DocumentValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.InvalidDocument);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        string document = value as string ?? "";
        if (document.Length < 11
            || new Regex("^\\d+$").Match(document).Success == false
            || document == "11111111111"
            || document == "22222222222"
            || document == "33333333333"
            || document == "44444444444"
            || document == "55555555555"
            || document == "66666666666"
            || document == "77777777777"
            || document == "88888888888"
            || document == "99999999999")
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        string documentWithoutDigits1 = document[..^2];
        var total1 = 0;
        var mul1 = 2;
        foreach (var digit in documentWithoutDigits1.Split())
        {
            var digitInt = Convert.ToInt32(digit);
            total1 += digitInt * mul1++;
        }
        var rest1 = total1 % 11;
        var digit1 = rest1 < 2 ? 0 : 11 - rest1;
        if (Convert.ToInt32(document[9]) != digit1)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        string documentWithoutDigits2 = documentWithoutDigits1 + digit1;
        var total2 = 0;
        var mul2 = 2;
        foreach (var digit in documentWithoutDigits2.Split())
        {
            var digitInt = Convert.ToInt32(digit);
            total2 += digitInt * mul2++;
        }
        var rest2 = total2 % 11;
        var digit2 = rest2 < 2 ? 0 : 11 - rest2;
        if (Convert.ToInt32(document[10]) != digit2)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        return ValidationResult.Success;
    }
}
