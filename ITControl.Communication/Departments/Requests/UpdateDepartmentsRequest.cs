using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    [StringMaxLength(10)]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string? Alias { get; set; }
    
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }
}