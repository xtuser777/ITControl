using ITControl.Application.Interfaces;
using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Calls.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;
[Route("calls")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CallsController(
    ICallsService callsService,
    ICallsView callsView) : ControllerBase
{
    [HttpGet]
    public async Task<FindManyResponse<FindManyCallsResponse>> Index(
        [FromQuery] FindManyCallsRequest request)
    {
        var calls = await callsService.FindMany(request);
        var pagination = await callsService.FindManyPagination(request);
        var data = callsView.FindMany(calls);
        return new FindManyResponse<FindManyCallsResponse>()
        {
            Data = data,
            Pagination = pagination
        };
    }

    [HttpGet("{id:guid}")]
    public async Task<FindOneResponse<FindOneCallsResponse?>> Show(Guid id)
    {
        var call = await callsService.FindOne(id, true, true, true, true);
        var data = callsView.FindOne(call);
        return new FindOneResponse<FindOneCallsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    public async Task<FindOneResponse<CreateCallsResponse?>> Create(CreateCallsRequest request)
    {
        var call = await callsService.Create(request);
        var data = callsView.Create(call);
        Response.StatusCode = StatusCodes.Status201Created;
        return new FindOneResponse<CreateCallsResponse?>()
        {
            Data = data,
        };
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await callsService.Delete(id);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
