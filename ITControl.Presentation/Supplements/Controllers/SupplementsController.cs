using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Supplements.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Supplements.Params;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[PermissionsFilter]
[Authorize(
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SupplementsController(
    ISupplementsService supplementsService,
    ISupplementsView supplementsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManySupplementsResponse>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Index(
        [AsParameters] IndexSupplementsParams @params)
    {
        var supplements = 
            await supplementsService.FindManyAsync(@params);
        var pagination = 
            await supplementsService.FindManyPagination(@params);
        var response = new 
        {
            Data = supplementsView.FindMany(supplements),
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneSupplementsResponse?>), 
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
        [AsParameters] ShowSupplementsParams @params)
    {
        var supplement = 
            await supplementsService.FindOneAsync(@params);
        var data = supplementsView.FindOne(supplement);
        var response = new
        {
            Data = data
        };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateSupplementsResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(
        [AsParameters] CreateSupplementsParams @params)
    {
        var supplement = 
            await supplementsService.CreateAsync(@params);
        var data = supplementsView.Create(supplement);
        var response = new
        {
            Data = data
        };
        return CreatedAtAction(
            nameof(Show), new { id = data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
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
    public async Task<IActionResult> Update(
        [AsParameters] UpdateSupplementsParams @params)
    {
        await supplementsService.UpdateAsync(@params);
        return NoContent();
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
        [AsParameters] DeleteSupplementsParams @params)
    {
        await supplementsService.DeleteAsync(@params);
        return NoContent();
    }
}
