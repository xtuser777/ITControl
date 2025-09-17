using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = nameof(Version), ResourceType = typeof(DisplayNames))]
    public string? Version { get; set; }

    [DateValue]
    [Display(Name = nameof(ImplementedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? ImplementedAt { get; set; }

    [DateValue]
    [DateGreatherThan(nameof(ImplementedAt))]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }

    [BoolValue]
    [Display(Name = nameof(Own), ResourceType = typeof(DisplayNames))]
    public bool? Own { get; set; }

    [GuidValue]
    [ContractConnection]
    [Display(Name = nameof(ContractId), ResourceType = typeof(DisplayNames))]
    public Guid? ContractId { get; set; }
}