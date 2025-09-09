using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Supplements.Requests;

public class UpdateSupplementsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "marca")]
    public string? Brand { get; set; } = null!;

    [StringMaxLength(100)]
    [Display(Name = "modelo")]
    public string? Model { get; set; } = null!;

    [Display(Name = "tipo")]
    [CustomValidation(typeof(UpdateSupplementsRequest), nameof(ValidateType))]
    public string? Type { get; set; } = null!;

    [IntegerPositiveValue]
    [Display(Name = "quantidade em estoque")]
    public int? Stock { get; set; }

    public static ValidationResult? ValidateType(string? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        var validTypes = Enum.GetNames(typeof(Domain.Supplements.Enums.SupplementType));
        if (!validTypes.Contains(x))
            return new ValidationResult($"O campo {context.DisplayName} deve ser um dos seguintes valores: {string.Join(", ", validTypes)}.");
        return ValidationResult.Success;
    }
}
