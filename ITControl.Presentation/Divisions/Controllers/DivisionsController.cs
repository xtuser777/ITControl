using ITControl.Application.Divisions.Interfaces;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Divisions.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Controllers;

[Route("divisions")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DivisionsController(
    IDivisionsService divisionsService, 
    IDivisionsView divisionsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FindManyResponse<FindManyDivisionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindManyResponse<FindManyDivisionsResponse>> IndexAsync(
        [FromQuery] FindManyDivisionsRequest request)
    {
        var divisions = await divisionsService.FindManyAsync(request);
        var pagination = await divisionsService.FindManyPaginatedAsync(request);
        var data = divisionsView.FindMany(divisions);

        return new FindManyResponse<FindManyDivisionsResponse>()
        {
            Data = data,
            Pagination = pagination
        };
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FindOneResponse<FindOneDivisionsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<FindOneDivisionsResponse?>> ShowAsync([FromRoute] Guid id)
    {
        var division = await divisionsService.FindOneAsync(id); 
        var data = divisionsView.FindOne(division);
        
        return new FindOneResponse<FindOneDivisionsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(FindOneResponse<CreateDivisionsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<CreateDivisionsResponse?>> CreateAsync(
        [FromBody] CreateDivisionsRequest request)
    {
        var division = await divisionsService.CreateAsync(request);
        var data = divisionsView.Create(division);
        Response.StatusCode = 201;
        return new FindOneResponse<CreateDivisionsResponse?>()
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
        [FromBody] UpdateDivisionsRequest request)
    {
        await divisionsService.UpdateAsync(id, request);
        Response.StatusCode = 204;
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task DeleteAsync([FromRoute] Guid id)
    {
        await divisionsService.DeleteAsync(id);
        Response.StatusCode = 204;
    }
}
