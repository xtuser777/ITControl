using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class CreateSystemsRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "versão")]
    public string Version { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreaterThanCurrent]
    [Display(Name = "data de implementação")]
    public DateOnly ImplementedAt { get; set; }

    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreatherThan("ImplementedAt")]
    [Display(Name = "data de desativação")]
    public DateOnly? EndedAt { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [BoolValue]
    [Display(Name = "próprio")]
    public bool Own { get; set; }

    [GuidValue]
    [Display(Name = "identificador do contrato")]
    public Guid? ContractId { get; set; }
}