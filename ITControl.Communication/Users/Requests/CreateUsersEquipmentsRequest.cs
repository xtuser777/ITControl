using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersEquipmentsRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "equipamento")]
    public Guid EquipmentId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [Display(Name = "data de início")]
    public DateOnly StartedAt { get; set; }

    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [Display(Name = "data de término")]
    public DateOnly? EndedAt { get; set; }
}