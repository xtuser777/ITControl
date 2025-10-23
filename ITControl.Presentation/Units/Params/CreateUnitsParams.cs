using ITControl.Application.Shared.Params;
using ITControl.Communication.Units.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record CreateUnitsParams
{
    [FromBody] public CreateUnitsRequest 
        CreateUnitsRequest { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateUnitsParams parameters)
        => new()
        {
            Params = parameters.CreateUnitsRequest
        };
}