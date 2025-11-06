using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Users.Entities;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Users.Requests;

public class CreateUsersSystemsRequest
{
    [RequiredField]
    [GuidValue]
    [SystemConnection]
    [Display(Name = nameof(SystemId), ResourceType = typeof(DisplayNames))]
    public Guid SystemId { get; set; }

    public static implicit operator UserSystem(CreateUsersSystemsRequest request)
        => new(Guid.Empty, request.SystemId);
}