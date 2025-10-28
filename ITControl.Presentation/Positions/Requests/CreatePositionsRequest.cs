using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;

namespace ITControl.Presentation.Positions.Requests;

public record CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExistsPositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;
    
    public static implicit operator PositionParams(
        CreatePositionsRequest request) =>
        new() { Name = request.Name };
}