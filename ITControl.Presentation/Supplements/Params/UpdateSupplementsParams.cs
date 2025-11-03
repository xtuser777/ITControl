using ITControl.Application.Shared.Params;
using ITControl.Presentation.Supplements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record UpdateSupplementsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    
    [FromBody]
    public UpdateSupplementsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateSupplementsParams param)
        => new()
        {
            Id = param.Id,
            Props = param.Request
        };
}