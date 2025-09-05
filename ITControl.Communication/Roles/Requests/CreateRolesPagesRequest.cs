using ITControl.Communication.Shared.Attributes;
using System.ComponentModel;

namespace ITControl.Communication.Roles.Requests;

public class CreateRolesPagesRequest
{
    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [DisplayName("página")]
    public Guid PageId { get; set; }
}