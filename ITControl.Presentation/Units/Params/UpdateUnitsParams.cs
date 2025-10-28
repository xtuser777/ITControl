using ITControl.Application.Shared.Params;
using ITControl.Presentation.Units.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record UpdateUnitsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateUnitsRequest 
        UpdateUnitsRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateUnitsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Params = parameters.UpdateUnitsRequest
        };
}