using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersEquipmentsRequest
{
    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "equipamento")]
    public Guid EquipmentId { get; set; }

    [RequiredField]
    [DateOnlyConverter]
    [DateValue]
    [Display(Name = "data de in�cio")]
    public DateOnly StartedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [Display(Name = "data de t�rmino")]
    public DateOnly? EndedAt { get; set; }
}