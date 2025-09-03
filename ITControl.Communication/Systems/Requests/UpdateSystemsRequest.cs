using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "vers�o")]
    public string? Version { get; set; }

    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [Display(Name = "data de implementa��o")]
    public DateOnly? ImplementedAt { get; set; }

    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreatherThan("ImplementedAt")]
    [Display(Name = "data de desativa��o")]
    public DateOnly? EndedAt { get; set; }

    [BoolValue]
    [Display(Name = "pr�prio")]
    public bool? Own { get; set; }

    [GuidValue]
    [Display(Name = "identificador do contrato")]
    public Guid? ContractId { get; set; }
}