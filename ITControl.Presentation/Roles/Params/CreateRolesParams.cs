using ITControl.Application.Shared.Params;
using ITControl.Presentation.Roles.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record CreateRolesParams
{
    [FromBody] public CreateRolesRequest 
        CreateRolesRequest { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateRolesParams param)
        => new()
        {
            Props = param.CreateRolesRequest
        };
}