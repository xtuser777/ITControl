using ITControl.Application.Shared.Params;
using ITControl.Presentation.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record DeleteUsersParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public DeleteUsersRequest 
        DeleteUsersRequest { get; set; } = new();

    public static implicit operator DeleteServiceParams(
        DeleteUsersParams param)
        => new()
        {
            Id = param.Id,
        };
}