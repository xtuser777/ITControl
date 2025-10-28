using ITControl.Application.Users.Interfaces;
using ITControl.Presentation.Users.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Users.Params;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Users.Interfaces;

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
    [ProducesResponseType(
        typeof(Shared.Responses.FindManyResponse<FindManyUsersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexUsersParams parameters)
    {
        var pagination = await usersService.FindManyPaginationAsync(parameters);
        var users = await usersService.FindManyAsync(parameters);
        var data = usersView.FindMany(users);
        return Ok(new
        {
            Data = data, Pagination = pagination
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<FindOneUsersResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowUsersParams parameters)
    {
        var user = await usersService.FindOneAsync(parameters);
        var data = usersView.FindOne(user);
        return Ok(new
        {
            Data = data,
        });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<CreateUsersResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateUsersParams parameters)
    {
        var user = await usersService.CreateAsync(parameters);
        var data = usersView.Create(user);
        var uri = $"/users/{user?.Id}";
        return Created(uri, new
        {
            Data = data,
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateUsersParams parameters)
    {
        await usersService.UpdateAsync(parameters);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteUsersParams parameters)
    {
        await usersService.DeleteAsync(parameters);
        return NoContent();
    }
}