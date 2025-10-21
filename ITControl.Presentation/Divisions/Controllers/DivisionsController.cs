using ITControl.Application.Divisions.Interfaces;
using ITControl.Communication.Divisions.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Divisions.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DivisionsController(
    IDivisionsService divisionsService, 
    IDivisionsView divisionsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManyDivisionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexDivisionsControllerParams @params)
    {
        var divisions = await divisionsService.FindManyAsync(@params);
        var pagination = await divisionsService.FindManyPaginatedAsync(@params);
        var data = divisionsView.FindMany(divisions);
        return Ok(new 
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneDivisionsResponse?>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowDivisionsControllerParams @params)
    {
        var division = await divisionsService.FindOneAsync(@params); 
        var data = divisionsView.FindOne(division);
        return Ok(new { Data = data });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateDivisionsResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateDivisionsControllerParams @params)
    {
        var division = await divisionsService.CreateAsync(@params);
        var data = divisionsView.Create(division);
        var uri = $"/divisions/{data?.Id}";
        return Created(uri, new { Data = data });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateDivisionsControllerParams @params)
    {
        await divisionsService.UpdateAsync(@params);
        return NoContent();
    }

    [HttpDelete("/{id:guid}")]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteDivisionsControllerParams @params)
    {
        await divisionsService.DeleteAsync(@params);
        return NoContent();
    }
}
