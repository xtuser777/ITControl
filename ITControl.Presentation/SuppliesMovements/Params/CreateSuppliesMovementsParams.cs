using ITControl.Application.Shared.Params;
using ITControl.Presentation.SuppliesMovements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SuppliesMovements.Params;

public record CreateSuppliesMovementsParams
{
    [FromBody]
    public CreateSuppliesMovementsRequest Request { get; set; } = new();
    
    public static implicit operator CreateServiceParams(
        CreateSuppliesMovementsParams param)
        => new() { Props = param.Request };
}