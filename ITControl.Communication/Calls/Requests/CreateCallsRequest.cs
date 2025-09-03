using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Calls.Requests;

public class CreateCallsRequest
{
    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(
        64, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "título")]
    public string Title { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(
        255, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "motivo")]
    public string Reason { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    [GuidValue]
    [Display(Name = "equipamento")]
    public Guid? EquipmentId { get; set; }

    [GuidValue]
    [Display(Name = "sistema")]
    public Guid? SystemId { get; set; }
}
