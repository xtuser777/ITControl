using ITControl.Application.Shared.Params;
using ITControl.Presentation.SupplementsMovements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record CreateSupplementsMovementsParams
{
    [FromBody]
    public CreateSupplementsMovementsRequest Request { get; set; } = new();
    
    public static implicit operator CreateServiceParams(
        CreateSupplementsMovementsParams param)
        => new() { Props = param.Request };
}