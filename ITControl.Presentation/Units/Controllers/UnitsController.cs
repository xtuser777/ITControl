using ITControl.Application.Units.Interfaces;
using ITControl.Presentation.Units.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Units.Params;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Units.Interfaces;

namespace ITControl.Presentation.Units.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UnitsController(
    IUnitsService unitsService,
    IUnitsView unitsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(Shared.Responses.FindManyResponse<FindManyUnitsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexUnitsParams parameters)
    {
        var units = await unitsService.FindManyAsync(parameters);
        var pagination = await unitsService.FindManyPaginationAsync(parameters);
        var data = unitsView.FindMany(units);

        return Ok(new
        {
            Data = data, Pagination = pagination,
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<FindOneUnitsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowUnitsParams parameters)
    {
        var unit = await unitsService.FindOneAsync(parameters);
        var data = unitsView.FindOne(unit);

        return Ok(new
        {
            Data = data,
        });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<CreateUnitsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateUnitsParams parameters)
    {
        var unit = await unitsService.CreateAsync(parameters);
        var data = unitsView.Create(unit);
        var uri = $"/units/{data?.Id}";
        return Created(uri, new
        {
            Data = data,
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateUnitsParams parameters)
    {
        await unitsService.UpdateAsync(parameters);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteUnitsParams parameters)
    {
        await unitsService.DeleteAsync(parameters);
        return NoContent();
    }
}