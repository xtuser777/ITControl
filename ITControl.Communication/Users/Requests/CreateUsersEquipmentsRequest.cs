using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Resources;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersEquipmentsRequest
{
    [RequiredField]
    [GuidValue]
    [EquipmentConnection]
    [Display(Name = nameof(EquipmentId), ResourceType = typeof(DisplayNames))]
    public Guid EquipmentId { get; set; }

    [RequiredField]
    [DateValue]
    [Display(Name = nameof(StartedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly StartedAt { get; set; }

    [DateValue]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }
}