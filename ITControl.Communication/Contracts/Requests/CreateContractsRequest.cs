using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Params;

namespace ITControl.Communication.Contracts.Requests;

public record CreateContractsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(ObjectName), ResourceType = typeof(DisplayNames))]
    public string ObjectName { get; set; } = string.Empty;

    [RequiredField]
    [DateValue]
    [DatePresentPast]
    [Display(Name = nameof(StartedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly StartedAt { get; set; }

    [DateValue]
    [DateGreatherThan(nameof(StartedAt))]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }

    [RequiredField]
    [Display(Name = nameof(Contacts), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];

    public static implicit operator ContractParams(
        CreateContractsRequest request) =>
        new()
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            ContractContacts = request.Contacts
                .Select(c => new ContractContact(
                    Guid.Empty, c))
        };
}