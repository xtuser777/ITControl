using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

public record UpdateDepartmentsRequest
{
    [StringMaxLength(10)]
    [UniqueField(typeof(IDepartmentsRepository), typeof(ExclusiveDepartmentsRepositoryParams))]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string? Alias { get; set; }
    
    [StringMaxLength(100)]
    [UniqueField(typeof(IDepartmentsRepository), typeof(ExclusiveDepartmentsRepositoryParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    public static implicit operator UpdateDepartmentParams(UpdateDepartmentsRequest request) =>
        new()
        {
            Alias = request.Alias,
            Name = request.Name
        };
}