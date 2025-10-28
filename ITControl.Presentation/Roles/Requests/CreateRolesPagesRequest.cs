using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Roles.Requests;

public record CreateRolesPagesRequest
{
    [RequiredField]
    [GuidValue]
    [PageConnection]
    [Display(Name = nameof(PageId), ResourceType = typeof(DisplayNames))]
    public Guid PageId { get; set; }
}