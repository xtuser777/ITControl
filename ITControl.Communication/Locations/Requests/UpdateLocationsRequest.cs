using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Locations.Requests;

public class UpdateLocationsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string? Description { get; set; }

    [GuidValue]
    [UnitConnection]
    [Display(Name = nameof(UnitId), ResourceType = typeof(DisplayNames))]
    public Guid? UnitId { get; set; }

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    [GuidValue]
    [DivisionConnection]
    [Display(Name = nameof(DivisionId), ResourceType = typeof(DisplayNames))]
    public Guid? DivisionId { get; set; }
}