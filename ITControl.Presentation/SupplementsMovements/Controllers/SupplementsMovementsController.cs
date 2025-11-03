using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.SupplementsMovements.Interfaces;
using ITControl.Presentation.SupplementsMovements.Params;
using ITControl.Presentation.SupplementsMovements.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Controllers;

[Route("supplements-movements")]
[ApiController]
public class SupplementsMovementsController(
    ISupplementsMovementsService supplementsMovementsService,
    ISupplementsMovementsView supplementsMovementsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManySupplementsMovementsResponse>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Index(
        [AsParameters] IndexSupplementsMovementsParams indexParams)
    {
        var supplementsMovements = 
            await supplementsMovementsService.FindManyAsync(indexParams);
        var pagination = 
            await supplementsMovementsService.FindManyPaginationAsync(indexParams);
        var data = 
            supplementsMovementsView.FindMany(supplementsMovements);
        var response = new
        {
            Data = data,
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneSupplementsMovementsResponse?>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status404NotFound)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Show(
        [AsParameters] ShowSupplementsMovementsParams showParams)
    {
        var supplementMovement = 
            await supplementsMovementsService.FindOneAsync(showParams);
        var data = 
            supplementsMovementsView.FindOne(supplementMovement);
        var response = new { Data = data };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateSupplementsMovementsResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(
        [AsParameters] CreateSupplementsMovementsParams createParams)
    {
        var supplementMovement = 
            await supplementsMovementsService.CreateAsync(createParams);
        var data = 
            supplementsMovementsView.Create(supplementMovement);
        var response = new { Data = data };

        return CreatedAtAction(
            nameof(Show), new { id = supplementMovement.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status404NotFound)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete(
        [AsParameters] DeleteSupplementsMovementsParams deleteParams)
    {
        await supplementsMovementsService.DeleteAsync(deleteParams);
        return NoContent();
    }
}
