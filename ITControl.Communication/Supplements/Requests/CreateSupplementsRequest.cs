using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Supplements.Requests;

public class CreateSupplementsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Brand), ResourceType = typeof(DisplayNames))]
    public string Brand { get; set; } = null!;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Model), ResourceType = typeof(DisplayNames))]
    public string Model { get; set; } = null!;

    [RequiredField]
    [CustomValidation(typeof(CreateSupplementsRequest), nameof(ValidateType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string Type { get; set; } = null!;

    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int Stock { get; set; }

    public static ValidationResult? ValidateType(string x, ValidationContext context)
    {
        var validTypes = Enum.GetNames(typeof(Domain.Supplements.Enums.SupplementType));
        var types = string.Join(", ", validTypes);
        if (!validTypes.Contains(x))
            return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, types));
        return ValidationResult.Success;
    }
}
