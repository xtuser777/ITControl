using ITControl.Application.Divisions.Interfaces;
using ITControl.Presentation.Divisions.Interfaces;
using ITControl.Presentation.Divisions.Responses;
using ITControl.Presentation.Divisions.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

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
        typeof(Shared.Responses.FindManyResponse<FindManyDivisionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexDivisionsParams @params)
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
        typeof(Shared.Responses.FindOneResponse<FindOneDivisionsResponse?>), 
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
        [AsParameters] ShowDivisionsParams @params)
    {
        var division = await divisionsService.FindOneAsync(@params); 
        var data = divisionsView.FindOne(division);
        return Ok(new { Data = data });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<CreateDivisionsResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), 
        StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateDivisionsParams @params)
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
        [AsParameters] UpdateDivisionsParams @params)
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
        [AsParameters] DeleteDivisionsParams @params)
    {
        await divisionsService.DeleteAsync(@params);
        return NoContent();
    }
}
