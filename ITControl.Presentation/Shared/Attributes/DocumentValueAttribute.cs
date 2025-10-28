using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

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
        for (var i = 0; i < documentWithoutDigits1.Length; i++)
        {
            var digitInt = Convert.ToInt32(documentWithoutDigits1[i].ToString());
            total1 += digitInt * (10 - i);
        }
        var rest1 = total1 % 11;
        var digit1 = rest1 < 2 ? 0 : 11 - rest1;
        if (Convert.ToInt32(document[9].ToString()) != digit1)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        string documentWithoutDigits2 = documentWithoutDigits1 + digit1;
        var total2 = 0;
        for (var i = 0; i < documentWithoutDigits2.Length; i++)
        {
            var digitInt = Convert.ToInt32(documentWithoutDigits2[i].ToString());
            total2 += digitInt * (11 - i);
        }
        var rest2 = total2 % 11;
        var digit2 = rest2 < 2 ? 0 : 11 - rest2;
        if (Convert.ToInt32(document[10].ToString()) != digit2)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        return ValidationResult.Success;
    }
}
