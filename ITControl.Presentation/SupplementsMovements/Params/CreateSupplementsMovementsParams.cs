using ITControl.Application.SupplementsMovements.Params;
using ITControl.Communication.SupplementsMovements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record CreateSupplementsMovementsParams
{
    [FromBody]
    public CreateSupplementsMovementsRequest Request { get; set; } = new();
    
    public static implicit operator CreateSupplementsMovementsServiceParams(
        CreateSupplementsMovementsParams param)
        => new() { Params = param.Request };
}