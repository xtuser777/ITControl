using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Contracts.Requests;

public class UpdateContractsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }

    [Required(ErrorMessage = "O campo 'contatos' é obrigatório")]
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}