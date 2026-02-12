using ITControl.Application.Shared.Params;
using ITControl.Presentation.Supplies.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Params;

public record UpdateSuppliesParams
{
    [FromRoute]
    public Guid Id { get; set; }
    
    [FromBody]
    public UpdateSuppliesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateSuppliesParams param)
        => new()
        {
            Id = param.Id,
            Props = param.Request
        };
}