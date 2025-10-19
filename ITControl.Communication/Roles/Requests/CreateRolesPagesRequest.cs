using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;

namespace ITControl.Communication.Roles.Requests;

public record CreateRolesPagesRequest
{
    [RequiredField]
    [GuidValue]
    [PageConnection]
    [Display(Name = nameof(PageId), ResourceType = typeof(DisplayNames))]
    public Guid PageId { get; set; }
}