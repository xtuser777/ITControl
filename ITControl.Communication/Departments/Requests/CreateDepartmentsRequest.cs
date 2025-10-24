using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

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

    public static implicit operator DepartmentParams(
        CreateDepartmentsRequest request) =>
        new()
        {
            Alias = request.Alias,
            Name = request.Name
        };
}