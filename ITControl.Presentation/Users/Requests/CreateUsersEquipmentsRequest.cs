using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Users.Entities;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Users.Requests;

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

    public static implicit operator UserEquipment(CreateUsersEquipmentsRequest request)
        => new (Guid.Empty, request.EquipmentId, request.StartedAt, request.EndedAt);
}