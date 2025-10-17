using ITControl.Application.Positions.Interfaces;
using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Positions.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [ProducesResponseType(typeof(FindManyResponse<FindManyPositionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [FromQuery] FindManyPositionsRequest request,
        [FromHeader] OrderByPositionsRequest orderBy)
    {
        var positions = await positionsService.FindManyAsync(request, orderBy);
        var data = positionsView.FindMany(positions);
        var pagination = await positionsService.FindManyPaginationAsync(request);

        return Ok(new {
            Data = data,
            Pagination = pagination,
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FindOneResponse<FindOnePositionsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync([AsParameters] FindOnePositionsRequest request)
    {
        var position = await positionsService.FindOneAsync(request);
        var data = positionsView.FindOne(position);

        return Ok(new { Data = data });
    }

    [HttpPost]
    [ProducesResponseType(typeof(FindOneResponse<CreatePositionsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<CreatePositionsResponse?>> CreateAsync(
        [FromBody] CreatePositionsRequest request)
    {
        var position = await positionsService.CreateAsync(request);
        var data = positionsView.Create(position);
        Response.StatusCode = 201;
        return new FindOneResponse<CreatePositionsResponse?>()
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
    public async Task<ActionResult> UpdateAsync(
        Guid id, 
        [FromBody] UpdatePositionsRequest request)
    {
        await positionsService.UpdateAsync(id, request);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await positionsService.DeleteAsync(id);
        
        return NoContent();
    }
}