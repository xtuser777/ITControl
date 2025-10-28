using ITControl.Application.Positions.Interfaces;
using ITControl.Presentation.Positions.Interfaces;
using ITControl.Presentation.Positions.Responses;
using ITControl.Presentation.Positions.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Positions.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PositionsController(
    IPositionsService positionsService, 
    IPositionsView positionsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManyPositionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexPositionsParams @params)
    {
        var positions = await positionsService.FindManyAsync(@params);
        var data = positionsView.FindMany(positions);
        var pagination = await positionsService.FindManyPaginationAsync(@params);
        return Ok(new { Data = data, Pagination = pagination });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOnePositionsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowPositionsParams @params)
    {
        var position = await positionsService.FindOneAsync(@params);
        var data = positionsView.FindOne(position);
        return Ok(new { Data = data });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreatePositionsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreatePositionsParams @params)
    {
        var position = await positionsService.CreateAsync(@params);
        var data = positionsView.Create(position);
        var uri = Url.Action("ShowAsync", new { id = data?.Id });
        return Created(uri, new { Data = data });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateAsync(
        [AsParameters] UpdatePositionsParams @params)
    {
        await positionsService.UpdateAsync(@params);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteAsync(
        [AsParameters] DeletePositionsParams @params)
    {
        await positionsService.DeleteAsync(@params);
        return NoContent();
    }
}