using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SuppliesMovements.Params;

public record DeleteSuppliesMovementsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    
    public static implicit operator DeleteServiceParams(
        DeleteSuppliesMovementsParams param)
        => new() { Id = param.Id };
}