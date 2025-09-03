using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class CreateRolesPagesRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [DisplayName("página")]
    public Guid PageId { get; set; }
}