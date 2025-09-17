using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Supplements.Requests;

public class UpdateSupplementsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Brand), ResourceType = typeof(DisplayNames))]
    public string? Brand { get; set; } = null!;

    [StringMaxLength(100)]
    [Display(Name = nameof(Model), ResourceType = typeof(DisplayNames))]
    public string? Model { get; set; } = null!;

    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    [CustomValidation(typeof(UpdateSupplementsRequest), nameof(ValidateType))]
    public string? Type { get; set; } = null!;

    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int? Stock { get; set; }

    public static ValidationResult? ValidateType(string? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        var validTypes = Enum.GetNames(typeof(Domain.Supplements.Enums.SupplementType));
        var types = string.Join(", ", validTypes);
        if (!validTypes.Contains(x))
            return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, types));
        return ValidationResult.Success;
    }
}
