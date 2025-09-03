using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(
        100, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "id do departamento")]
    public Guid DepartmentId { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "id do usuário")]
    public Guid UserId { get; set; }
}