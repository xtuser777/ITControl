using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Divisions.Requests;

public record UpdateDivisionsRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }
    
    [FromBody]
    [StringMaxLength(100)]
    [UniqueField(typeof(IDivisionsRepository), typeof(ExclusiveDivisionsRepositoryParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [FromBody]
    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid? DepartmentId { get; set; }

    public static implicit operator FindOneDivisionsRequest(UpdateDivisionsRequest request)
        => new FindOneDivisionsRequest
        {
            Id = request.Id,
        };

    public static implicit operator UpdateDivisionParams(UpdateDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };
}