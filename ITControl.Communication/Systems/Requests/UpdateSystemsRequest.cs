using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = "vers�o")]
    public string? Version { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [Display(Name = "data de implementa��o")]
    public DateOnly? ImplementedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreatherThan("ImplementedAt")]
    [Display(Name = "data de desativa��o")]
    public DateOnly? EndedAt { get; set; }

    [BoolValue]
    [Display(Name = "pr�prio")]
    public bool? Own { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "identificador do contrato")]
    public Guid? ContractId { get; set; }
}