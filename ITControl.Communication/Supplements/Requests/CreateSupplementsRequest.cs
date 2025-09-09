using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Supplements.Requests;

public class CreateSupplementsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "marca")]
    public string Brand { get; set; } = null!;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "modelo")]
    public string Model { get; set; } = null!;

    [RequiredField]
    [CustomValidation(typeof(CreateSupplementsRequest), nameof(ValidateType))]
    [Display(Name = "tipo")]
    public string Type { get; set; } = null!;

    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = "quantidade em estoque")]
    public int Stock { get; set; }

    public static ValidationResult? ValidateType(string x, ValidationContext context)
    {
        var validTypes = Enum.GetNames(typeof(Domain.Supplements.Enums.SupplementType));
        if (!validTypes.Contains(x))
            return new ValidationResult($"O campo {context.DisplayName} deve ser um dos seguintes valores: {string.Join(", ", validTypes)}.");
        return ValidationResult.Success;
    }
}
