using ITControl.Application.Systems.Params;
using ITControl.Communication.Systems.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record CreateSystemsParams
{
    [FromBody] public CreateSystemsRequest 
        CreateSystemsRequest { get; set; } = new();

    public static implicit operator CreateSystemsServiceParams(
        CreateSystemsParams parameters)
        => new()
        {
            Params = parameters.CreateSystemsRequest
        };
}