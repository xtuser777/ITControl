using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.SupplementsMovements.Requests;
using ITControl.Communication.SupplementsMovements.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Controllers;
[Route("supplements-movements")]
[ApiController]
public class SupplementsMovementsController(
    ISupplementsMovementsService supplementsMovementsService,
    ISupplementsMovementsView supplementsMovementsView) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] FindManySupplementsMovementsRequest request)
    {
        var supplementsMovements = await supplementsMovementsService.FindManyAsync(request);
        var pagination = await supplementsMovementsService.FindManyPaginationAsync(request);
        var data = supplementsMovementsView.FindMany(supplementsMovements);
        var response = new FindManyResponse<FindManySupplementsMovementsResponse>()
        {
            Data = data,
            Pagination = pagination
        };

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Show([FromRoute] Guid id,
        [FromQuery] bool? includeSupplement = true,
        [FromQuery] bool? includeUser = true,
        [FromQuery] bool? includeUnit = true,
        [FromQuery] bool? includeDepartment = true,
        [FromQuery] bool? includeDivision = true)
    {
        var supplementMovement = await supplementsMovementsService.FindOneAsync(
            id, includeSupplement, includeUser, includeUnit, includeDepartment, includeDivision);
        var data = supplementsMovementsView.FindOne(supplementMovement);
        var response = new FindOneResponse<FindOneSupplementsMovementsResponse?>()
        {
            Data = data
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplementsMovementsRequest request)
    {
        var supplementMovement = await supplementsMovementsService.CreateAsync(request);
        var data = supplementsMovementsView.Create(supplementMovement);
        var response = new FindOneResponse<CreateSupplementsMovementsResponse?>()
        {
            Data = data
        };

        return CreatedAtAction(nameof(Show), new { id = supplementMovement.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await supplementsMovementsService.DeleteAsync(id);
        return NoContent();
    }
}
