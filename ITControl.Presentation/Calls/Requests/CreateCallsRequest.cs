using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Calls.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;

namespace ITControl.Presentation.Calls.Requests;

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
    [EnumValue(typeof(CallReason))]
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

    public static implicit operator CallProps(
        CreateCallsRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnum<CallReason>(request.Reason),
            EquipmentId = request.EquipmentId,  
            SystemId = request.SystemId,
            UserId = request.UserId,
        };
}
