using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Positions.Params;

namespace ITControl.Communication.Positions.Requests;

public class UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string? Description { get; set; }
    
    public static implicit operator UpdatePositionParams(UpdatePositionsRequest request) => 
        new() { Description = request.Description };
}