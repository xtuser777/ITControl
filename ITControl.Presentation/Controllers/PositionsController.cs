using ITControl.Application.Interfaces;
using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Positions.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class PositionsController(IPositionsService positionsService, IPositionsView positionsView) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<FindManyResponse<FindManyPositionsResponse>>> Index([FromQuery] FindManyPositionsRequest request)
    {
        var positions = await positionsService.FindMany(request);
        var data = positionsView.FindMany(positions);
        var pagination = await positionsService.FindManyPagination(request);

        var response = new FindManyResponse<FindManyPositionsResponse>()
        {
            Data = data,
            Pagination = pagination,
        };
        
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FindOnePositionsResponse?>> Show(Guid id)
    {
        var position = await positionsService.FindOne(id);
        var data = positionsView.FindOne(position);
        
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<CreatePositionsRequest?>> Create([FromBody] CreatePositionsRequest request)
    {
        var position = await positionsService.Create(request);
        var data = positionsView.Create(position);
        
        return Ok(data);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePositionsRequest request)
    {
        await positionsService.Update(id, request);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await positionsService.Delete(id);
        
        return NoContent();
    }
}