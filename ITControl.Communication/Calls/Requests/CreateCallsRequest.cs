using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Calls.Requests;

public class CreateCallsRequest
{
    [RequiredField]
    [StringMaxLength(64)]
    [Display(Name = nameof(Title), ResourceType = typeof(DisplayNames))]
    public string Title { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(255)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [CustomValidation(typeof(CreateCallsRequest), nameof(ValidateReason))]
    [Display(Name = nameof(Reason), ResourceType = typeof(DisplayNames))]
    public string Reason { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }

    [GuidValue]
    [EquipmentConnection]
    [Display(Name = nameof(EquipmentId), ResourceType = typeof(DisplayNames))]
    public Guid? EquipmentId { get; set; }

    [GuidValue]
    [SystemConnection]
    [Display(Name = nameof(SystemId), ResourceType = typeof(DisplayNames))]
    public Guid? SystemId { get; set; }

    public static ValidationResult? ValidateReason(string reason, ValidationContext context)
    {
        var validReasons = Enum.GetNames(typeof(CallReason));
        if (!validReasons.Contains(reason))
        {
            var reasons = string.Join(", ", validReasons);
            return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, reasons));
        }
        return ValidationResult.Success;
    }
}
