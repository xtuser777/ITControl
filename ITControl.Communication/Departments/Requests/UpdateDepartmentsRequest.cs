using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Departments.Entities;

namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    [StringMaxLength(10)]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string? Alias { get; set; }
    
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    public static implicit operator UpdateDepartmentParams(UpdateDepartmentsRequest request)
    {
        return new UpdateDepartmentParams
        {
            Alias = request.Alias,
            Name = request.Name
        };
    }
}