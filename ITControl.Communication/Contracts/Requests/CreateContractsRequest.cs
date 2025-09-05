using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "objeto")]
    public string ObjectName { get; set; } = string.Empty;

    [RequiredField]
    [DateOnlyConverter]
    [DateValue]
    [DatePresentPast]
    [Display(Name = "início")]
    public DateOnly StartedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreatherThan("StartedAt")]
    [Display(Name = "fim")]
    public DateOnly? EndedAt { get; set; }

    [RequiredField]
    [Display(Name = "contatos")]
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}