using ITControl.Application.Shared.Params;
using ITControl.Communication.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record CreateUsersParams
{
    [FromBody] public CreateUsersRequest 
        CreateUsersRequest { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateUsersParams param)
        => new()
        {
            Params = param.CreateUsersRequest
        };
}