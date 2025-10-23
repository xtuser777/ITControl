using ITControl.Application.Shared.Params;
using ITControl.Communication.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record UpdateUsersParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromBody] public UpdateUsersRequest 
        UpdateUsersRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateUsersParams param)
        => new()
        {
            Id = param.Id,
            Params = param.UpdateUsersRequest
        };
}