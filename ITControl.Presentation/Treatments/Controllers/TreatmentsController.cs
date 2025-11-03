using ITControl.Application.Treatments.Interfaces;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;
using ITControl.Presentation.Treatments.Params;
using ITControl.Presentation.Treatments.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TreatmentsController(
    ITreatmentsService treatmentsService,
    ITreatmentsView treatmentsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(
        typeof(Shared.Responses.FindManyResponse<FindManyTreatmentsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexTreatmentsParams parameters)
    {
        var treatments = 
            await treatmentsService.FindManyAsync(parameters);
        var pagination = 
            await treatmentsService.FindManyPaginationAsync(parameters);
        var data = treatmentsView.FindMany(treatments);
        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<FindOneTreatmentsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowTreatmentsParams parameters)
    {
        var treatment = await treatmentsService.FindOneAsync(parameters);
        var data = treatmentsView.FindOne(treatment);
        return Ok(new
        {
            Data = data,
        });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(Shared.Responses.FindOneResponse<CreateTreatmentsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateTreatmentsParams parameters)
    {
        var treatment = await treatmentsService.CreateAsync(parameters);
        var data = treatmentsView.Create(treatment);
        var uri = $"/treatments/{treatment?.Id}";
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
        [AsParameters] UpdateTreatmentsParams parameters)
    {
        await treatmentsService.UpdateAsync(parameters);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteTreatmentsParams parameters)
    {
        await treatmentsService.DeleteAsync(parameters);
        return NoContent();
    }
}
