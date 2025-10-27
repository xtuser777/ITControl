using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record DeleteSupplementsMovementsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    
    public static implicit operator DeleteServiceParams(
        DeleteSupplementsMovementsParams param)
        => new() { Id = param.Id };
}