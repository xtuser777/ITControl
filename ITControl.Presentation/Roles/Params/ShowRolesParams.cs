using ITControl.Application.Shared.Params;
using ITControl.Domain.Roles.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record ShowRolesParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? IncludesRolesPages { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowRolesParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesRolesParams()
            {
                RolesPages = new IncludesRolesPagesParams()
                {
                    Page = param.IncludesRolesPages
                }
            }
        };
}