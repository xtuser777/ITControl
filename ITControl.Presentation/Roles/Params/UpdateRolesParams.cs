using ITControl.Application.Shared.Params;
using ITControl.Communication.Roles.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record UpdateRolesParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateRolesRequest 
        UpdateRolesRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateRolesParams param)
        => new()
        {
            Id = param.Id,
            Params = param.UpdateRolesRequest
        };
}