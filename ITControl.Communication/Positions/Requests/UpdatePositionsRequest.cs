using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;

namespace ITControl.Communication.Positions.Requests;

public record UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExclusivePositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    public static implicit operator UpdatePositionParams(
        UpdatePositionsRequest request) => 
        new() { Name = request.Name };
}