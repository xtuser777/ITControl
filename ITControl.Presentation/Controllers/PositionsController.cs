using ITControl.Application.Interfaces;
using ITControl.Communication.Appointments.Responses;
using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Positions.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("positions")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PositionsController(IPositionsService positionsService, IPositionsView positionsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FindManyResponse<FindManyPositionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindManyResponse<FindManyPositionsResponse>> Index([FromQuery] FindManyPositionsRequest request)
    {
        var positions = await positionsService.FindMany(request);
        var data = positionsView.FindMany(positions);
        var pagination = await positionsService.FindManyPagination(request);

        return new FindManyResponse<FindManyPositionsResponse>()
        {
            Data = data,
            Pagination = pagination,
        };
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FindOneResponse<FindOnePositionsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<FindOnePositionsResponse?>> Show(Guid id)
    {
        var position = await positionsService.FindOne(id);
        var data = positionsView.FindOne(position);

        return new FindOneResponse<FindOnePositionsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(FindOneResponse<CreatePositionsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<CreatePositionsResponse?>> Create([FromBody] CreatePositionsRequest request)
    {
        var position = await positionsService.Create(request);
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
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePositionsRequest request)
    {
        await positionsService.Update(id, request);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await positionsService.Delete(id);
        
        return NoContent();
    }
}