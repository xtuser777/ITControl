using ITControl.Application.Shared.Params;
using ITControl.Presentation.Divisions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record UpdateDivisionsParams
{
    [FromRoute] 
    public Guid Id { get; set; }

    [FromBody] 
    public UpdateDivisionsRequest Request { get; set; } = null!;

    public static implicit operator UpdateServiceParams(
        UpdateDivisionsParams @params)
        => new ()
        {
            Id = @params.Id,
            Params = @params.Request
        };
}