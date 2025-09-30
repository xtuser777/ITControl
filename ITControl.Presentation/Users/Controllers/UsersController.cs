using ITControl.Application.Users.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Communication.Users.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController(
    IUsersService usersService,
    IUsersView usersView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FindManyResponse<FindManyUsersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindManyResponse<FindManyUsersResponse>> IndexAsync(
        [FromQuery] FindManyUsersRequest request)
    {
        var users = await usersService.FindManyAsync(request);
        var data = usersView.FindMany(users);
        var pagination = await usersService.FindManyPaginationAsync(request);

        return new FindManyResponse<FindManyUsersResponse>()
        {
            Data = data,
            Pagination = pagination
        };
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FindOneResponse<FindOneUsersResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<FindOneUsersResponse?>> ShowAsync([FromRoute] Guid id)
    {
        var user = await usersService.FindOneAsync(id, true, true, true, true);
        var data = usersView.FindOne(user);

        return new FindOneResponse<FindOneUsersResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(FindOneResponse<CreateUsersResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<CreateUsersResponse?>> CreateAsync(
        [FromBody] CreateUsersRequest request)
    {
        var user = await usersService.CreateAsync(request);
        var data = usersView.Create(user);
        this.Response.StatusCode = 201;
        return new FindOneResponse<CreateUsersResponse?>()
        {
            Data = data,
        };
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task UpdateAsync(
        [FromRoute] Guid id,
        [FromBody] UpdateUsersRequest request)
    {
        await usersService.UpdateAsync(id, request);
        this.Response.StatusCode = 204;
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task DeleteAsync(
        [FromRoute] Guid id, 
        [FromBody] DeleteUsersRequest request)
    {
        await usersService.DeleteAsync(id, request);
        this.Response.StatusCode = 204;
    }
}