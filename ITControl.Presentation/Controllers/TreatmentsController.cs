using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Communication.Treatments.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("treatments")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TreatmentsController(
    ITreatmentsService treatmentsService,
    ITreatmentsView treatmentsView) : ControllerBase
{
    [HttpGet]
    public async Task<FindManyResponse<FindManyTreatmentsResponse>> Index(
        [FromQuery] FindManyTreatmentsRequest request)
    {
        var treatments = await treatmentsService.FindManyAsync(request);
        var pagination = await treatmentsService.FindManyPaginationAsync(request);
        var data = treatmentsView.FindMany(treatments);
        return new FindManyResponse<FindManyTreatmentsResponse>()
        {
            Data = data,
            Pagination = pagination
        };
    }

    [HttpGet("{id:guid}")]
    public async Task<FindOneResponse<FindOneTreatmentsResponse?>> Show(Guid id)
    {
        var treatment = await treatmentsService.FindOneAsync(id, true, true);
        var data = treatmentsView.FindOne(treatment);
        return new FindOneResponse<FindOneTreatmentsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    public async Task<FindOneResponse<CreateTreatmentsResponse?>> Create(CreateTreatmentsRequest request)
    {
        var treatment = await treatmentsService.CreateAsync(request);
        var data = treatmentsView.Create(treatment);
        Response.StatusCode = StatusCodes.Status201Created;
        return new FindOneResponse<CreateTreatmentsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPut("{id:guid}")]
    public async Task Update(Guid id, UpdateTreatmentsRequest request)
    {
        await treatmentsService.UpdateAsync(id, request);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await treatmentsService.DeleteAsync(id);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
