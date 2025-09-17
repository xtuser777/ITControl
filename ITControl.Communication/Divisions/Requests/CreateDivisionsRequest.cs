using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid DepartmentId { get; set; }

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }
}