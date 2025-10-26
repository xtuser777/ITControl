using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;

namespace ITControl.Communication.Divisions.Requests;

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

    public static implicit operator UpdateDivisionParams(
        UpdateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}