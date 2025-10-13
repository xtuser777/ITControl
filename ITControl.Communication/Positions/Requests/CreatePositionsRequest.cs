using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Positions.Params;

namespace ITControl.Communication.Positions.Requests;

public class CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string Description { get; set; } = string.Empty;
    
    public static implicit operator PositionParams(CreatePositionsRequest request) =>
        new() { Description = request.Description };
}