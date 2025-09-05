using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = "versão")]
    public string? Version { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [Display(Name = "data de implementação")]
    public DateOnly? ImplementedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreatherThan("ImplementedAt")]
    [Display(Name = "data de desativação")]
    public DateOnly? EndedAt { get; set; }

    [BoolValue]
    [Display(Name = "próprio")]
    public bool? Own { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "identificador do contrato")]
    public Guid? ContractId { get; set; }
}