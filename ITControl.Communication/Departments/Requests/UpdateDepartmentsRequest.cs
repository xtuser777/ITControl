using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

public record UpdateDepartmentsRequest
{
    [StringMinLength(1)]
    [StringMaxLength(10)]
    [UniqueField<Department>(
        typeof(IDepartmentsRepository), 
        typeof(ExclusiveDepartmentsParams))]
    [Display(Name = nameof(Alias), ResourceType = typeof(DisplayNames))]
    public string? Alias { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(100)]
    [UniqueField<Department>(
        typeof(IDepartmentsRepository), 
        typeof(ExclusiveDepartmentsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    public static implicit operator UpdateDepartmentParams(
        UpdateDepartmentsRequest request) =>
        new()
        {
            Alias = request.Alias,
            Name = request.Name
        };
}