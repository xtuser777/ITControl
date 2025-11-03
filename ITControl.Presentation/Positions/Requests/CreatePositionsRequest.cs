using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Positions.Props;

namespace ITControl.Presentation.Positions.Requests;

public record CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExistsPositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;
    
    public static implicit operator PositionProps(
        CreatePositionsRequest request) =>
        new() { Name = request.Name };
}