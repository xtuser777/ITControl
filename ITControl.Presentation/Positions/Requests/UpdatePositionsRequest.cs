using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Positions.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Positions.Requests;

public record UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [UniqueField<Position>(
        typeof(IPositionsRepository), 
        typeof(ExclusivePositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    public static implicit operator PositionProps(
        UpdatePositionsRequest request) => 
        new() { Name = request.Name };
}