using ITControl.Application.Systems.Params;
using ITControl.Communication.Systems.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record UpdateSystemsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateSystemsRequest 
        UpdateSystemsRequest { get; set; } = new();

    public static implicit operator UpdateSystemsServiceParams(
        UpdateSystemsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Params = parameters.UpdateSystemsRequest
        };
}