using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Name { get; set; }
    
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Version { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public bool? Own { get; set; }
    public Guid? ContractId { get; set; }
}