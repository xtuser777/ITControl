using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Contracts.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Contracts.Requests;

public record CreateContractsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Enterprise), ResourceType = typeof(DisplayNames))]
    public string Enterprise { get; set; } = string.Empty;
    
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

    public static implicit operator ContractProps(
        CreateContractsRequest request) =>
        new()
        {
            Enterprise = request.Enterprise,
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            ContractContacts = [.. request.Contacts
                .Select(c => new ContractContact(
                    Guid.Empty, c))]
        };
}