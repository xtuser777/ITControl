using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Divisions.Props;

namespace ITControl.Presentation.Divisions.Requests;

public record UpdateDivisionsRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [UniqueField<Division>(
        typeof(IDivisionsRepository), 
        typeof(ExclusiveDivisionsParams))]
    [Display(
        Name = nameof(Name), 
        ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [GuidValue]
    [DepartmentConnection]
    [Display(
        Name = nameof(DepartmentId), 
        ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    public static implicit operator DivisionProps(
        UpdateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}