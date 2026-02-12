using ITControl.Application.Supplies.Interfaces;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Supplies.Interfaces;
using ITControl.Presentation.Supplies.Params;
using ITControl.Presentation.Supplies.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[PermissionsFilter]
[Authorize(
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SuppliesController(
    ISuppliesService suppliesService,
    ISuppliesView suppliesView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(FindManyResponse<FindManySuppliesResponse>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Index(
        [AsParameters] IndexSuppliesParams @params)
    {
        var supplies = 
            await suppliesService.FindManyAsync(@params);
        var pagination = 
            await suppliesService.FindManyPagination(@params);
        var response = new 
        {
            Data = suppliesView.FindMany(supplies),
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneSuppliesResponse?>), 
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
        [AsParameters] ShowSuppliesParams @params)
    {
        var supply = 
            await suppliesService.FindOneAsync(@params);
        var data = suppliesView.FindOne(supply);
        var response = new
        {
            Data = data
        };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateSuppliesResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), 
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(
        typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(
        [AsParameters] CreateSuppliesParams @params)
    {
        var supply = 
            await suppliesService.CreateAsync(@params);
        var data = suppliesView.Create(supply);
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
        [AsParameters] UpdateSuppliesParams @params)
    {
        await suppliesService.UpdateAsync(@params);
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
        [AsParameters] DeleteSuppliesParams @params)
    {
        await suppliesService.DeleteAsync(@params);
        return NoContent();
    }
}
