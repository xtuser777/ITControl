using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Converters;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class CreateSystemsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(50)]
    [Display(Name = "versão")]
    public string Version { get; set; } = string.Empty;

    [RequiredField]
    [DateOnlyConverter]
    [DateValue]
    [DateGreaterThanCurrent]
    [Display(Name = "data de implementação")]
    public DateOnly ImplementedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreatherThan("ImplementedAt")]
    [Display(Name = "data de desativação")]
    public DateOnly? EndedAt { get; set; }

    [RequiredField]
    [BoolValue]
    [Display(Name = "próprio")]
    public bool Own { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "identificador do contrato")]
    public Guid? ContractId { get; set; }
}