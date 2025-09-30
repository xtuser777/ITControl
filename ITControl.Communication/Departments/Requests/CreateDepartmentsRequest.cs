using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Departments.Entities;

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

    public static implicit operator Department(CreateDepartmentsRequest request)
    {
        return new Department(request.Alias, request.Name);
    }
}