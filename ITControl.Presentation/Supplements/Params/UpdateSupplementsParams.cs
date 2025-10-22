using ITControl.Application.Supplements.Params;
using ITControl.Communication.Supplements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record UpdateSupplementsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    
    [FromBody]
    public UpdateSupplementsRequest Request { get; set; } = new();

    public static implicit operator UpdateSupplementsServiceParams(
        UpdateSupplementsParams param)
        => new()
        {
            Id = param.Id,
            Params = param.Request
        };
}