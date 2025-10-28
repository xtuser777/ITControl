using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;

namespace ITControl.Presentation.Divisions.Requests;

public record CreateDivisionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Division>(
        typeof(IDivisionsRepository), 
        typeof(ExistsDivisionsParams))]
    [Display(
        Name = nameof(Name), 
        ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [DepartmentConnection]
    [Display(
        Name = nameof(DepartmentId), 
        ResourceType = typeof(DisplayNames))]
    public Guid DepartmentId { get; set; }

    public static implicit operator DivisionParams(
        CreateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}