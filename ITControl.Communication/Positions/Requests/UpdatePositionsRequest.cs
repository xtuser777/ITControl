using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Positions.Interfaces;

namespace ITControl.Communication.Positions.Requests;

public record UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [UniqueField(typeof(IPositionsRepository), typeof(ExclusivePositionsRepositoryParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    public static implicit operator UpdatePositionParams(UpdatePositionsRequest request) => 
        new() { Name = request.Name };
}