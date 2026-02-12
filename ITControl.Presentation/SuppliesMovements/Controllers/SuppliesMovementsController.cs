using ITControl.Application.SuppliesMovements.Interfaces;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.SuppliesMovements.Interfaces;
using ITControl.Presentation.SuppliesMovements.Params;
using ITControl.Presentation.SuppliesMovements.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SuppliesMovements.Controllers;

[Route("supplies-movements")]
[ApiController]
public class SuppliesMovementsController(
    ISuppliesMovementsService suppliesMovementsService,
    ISuppliesMovementsView suppliesMovementsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManySuppliesMovementsResponse>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Index(
        [AsParameters] IndexSuppliesMovementsParams indexParams)
    {
        var suppliesMovements = 
            await suppliesMovementsService.FindManyAsync(indexParams);
        var pagination = 
            await suppliesMovementsService.FindManyPaginationAsync(indexParams);
        var data = 
            suppliesMovementsView.FindMany(suppliesMovements);
        var response = new
        {
            Data = data,
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneSuppliesMovementsResponse?>), 
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
        [AsParameters] ShowSuppliesMovementsParams showParams)
    {
        var supplyMovement = 
            await suppliesMovementsService.FindOneAsync(showParams);
        var data = 
            suppliesMovementsView.FindOne(supplyMovement);
        var response = new { Data = data };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateSuppliesMovementsResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(
        [AsParameters] CreateSuppliesMovementsParams createParams)
    {
        var supplyMovement = 
            await suppliesMovementsService.CreateAsync(createParams);
        var data = 
            suppliesMovementsView.Create(supplyMovement);
        var response = new { Data = data };

        return CreatedAtAction(
            nameof(Show), new { id = supplyMovement.Id }, response);
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
        [AsParameters] DeleteSuppliesMovementsParams deleteParams)
    {
        await suppliesMovementsService.DeleteAsync(deleteParams);
        return NoContent();
    }
}
