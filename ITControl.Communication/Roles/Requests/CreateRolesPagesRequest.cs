using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class CreateRolesPagesRequest
{
    [RequiredField]
    [GuidValue]
    [PageConnection]
    [Display(Name = nameof(PageId), ResourceType = typeof(DisplayNames))]
    public Guid PageId { get; set; }
}