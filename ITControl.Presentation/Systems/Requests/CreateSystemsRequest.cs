using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Systems.Params;
using ITControl.Domain.Systems.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Systems.Requests;

public record CreateSystemsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(50)]
    [Display(Name = nameof(Version), ResourceType = typeof(DisplayNames))]
    public string Version { get; set; } = string.Empty;

    [RequiredField]
    [DateValue]
    [DatePresentPast]
    [Display(Name = nameof(ImplementedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly ImplementedAt { get; set; }

    [DateValue]
    [DateGreatherThan(nameof(ImplementedAt))]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }

    [RequiredField]
    [BoolValue]
    [Display(Name = nameof(Own), ResourceType = typeof(DisplayNames))]
    public bool Own { get; set; }

    [GuidValue]
    [ContractConnection]
    [Display(Name = nameof(ContractId), ResourceType = typeof(DisplayNames))]
    public Guid? ContractId { get; set; }

    public static implicit operator SystemProps(
        CreateSystemsRequest request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = request.Own,
            ContractId = request.ContractId
        };
}