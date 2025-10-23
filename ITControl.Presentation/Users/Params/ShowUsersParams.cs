using ITControl.Application.Shared.Params;
using ITControl.Domain.Users.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record ShowUsersParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? Position { get; init; } = true;
    [FromQuery] public bool? Role { get; init; } = true;
    [FromQuery] public bool? Unit { get; init; } = true;
    [FromQuery] public bool? Department { get; init; } = true;
    [FromQuery] public bool? Division { get; init; } = true;
    [FromQuery] public bool? UsersEquipments { get; set; } = true;
    [FromQuery] public bool? UsersSystems { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowUsersParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesUsersParams()
            {
                Position = param.Position,
                Role = param.Role,
                Unit = param.Unit,
                Department = param.Department,
                Division = param.Division,
                UsersEquipments = param.UsersEquipments,
                UsersSystems = param.UsersSystems,
            }
        };
}