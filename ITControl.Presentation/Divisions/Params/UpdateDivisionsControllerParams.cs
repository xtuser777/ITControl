using ITControl.Application.Divisions.Params;
using ITControl.Communication.Divisions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record UpdateDivisionsControllerParams
{
    [FromRoute] 
    public Guid Id { get; set; }

    [FromBody] 
    public UpdateDivisionsRequest Request { get; set; } = null!;

    public static implicit operator UpdateDivisionsServiceParams(
        UpdateDivisionsControllerParams @params)
        => new ()
        {
            Id = @params.Id,
            Params = @params.Request
        };
}