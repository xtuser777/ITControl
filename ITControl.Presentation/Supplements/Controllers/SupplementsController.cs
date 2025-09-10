using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Supplements.Requests;
using ITControl.Communication.Supplements.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Controllers;

[Route("supplements")]
[ApiController]
[Produces("application/json")]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SupplementsController(
    ISupplementsService supplementsService,
    ISupplementsView supplementsView) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<FindManyResponse<FindManySupplementsResponse>>> Index([FromQuery] FindManySupplementsRequest request)
    {
        var supplements = await supplementsService.FindManyAsync(request);
        var pagination = await supplementsService.FindManyPagination(request);
        var response = new FindManyResponse<FindManySupplementsResponse>()
        {
            Data = supplementsView.FindMany(supplements),
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FindOneResponse<FindOneSupplementsResponse>>> Show([FromRoute] Guid id)
    {
        var supplement = await supplementsService.FindOneAsync(id);
        var data = supplementsView.FindOne(supplement);
        var response = new FindOneResponse<FindOneSupplementsResponse?>()
        {
            Data = data
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<FindOneResponse<CreateSupplementsResponse>>> Create([FromBody] CreateSupplementsRequest request)
    {
        var supplement = await supplementsService.CreateAsync(request);
        var data = supplementsView.Create(supplement);
        var response = new FindOneResponse<CreateSupplementsResponse?>()
        {
            Data = data
        };
        return CreatedAtAction(nameof(Show), new { id = data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSupplementsRequest request)
    {
        await supplementsService.UpdateAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await supplementsService.DeleteAsync(id);
        return NoContent();
    }
}
