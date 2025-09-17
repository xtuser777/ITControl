using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Departments.Requests;

public class CreateDepartmentsRequest
{
    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string Alias { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }
}