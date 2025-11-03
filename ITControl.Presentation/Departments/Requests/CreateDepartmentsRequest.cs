using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Departments.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Departments.Requests;

public record CreateDepartmentsRequest
{
    [RequiredField]
    [StringMaxLength(10)]
    [UniqueField<Department>(
        typeof(IDepartmentsRepository), 
        typeof(ExistsDepartmentsParams))]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string Alias { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Department>(
        typeof(IDepartmentsRepository), 
        typeof(ExistsDepartmentsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    public static implicit operator DepartmentProps(
        CreateDepartmentsRequest request) =>
        new()
        {
            Alias = request.Alias,
            Name = request.Name
        };
}