using ITControl.Application.Shared.Params;
using ITControl.Presentation.Systems.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record UpdateSystemsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateSystemsRequest 
        UpdateSystemsRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateSystemsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Params = parameters.UpdateSystemsRequest
        };
}