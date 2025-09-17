using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Divisions.Requests;

public class UpdateDivisionsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }
}