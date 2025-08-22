using ITControl.Application.Interfaces;
using ITControl.Communication.Appointments.Responses;
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
    [ProducesResponseType(typeof(FindManyResponse<FindManyCallsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
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
    [ProducesResponseType(typeof(FindOneResponse<FindOneCallsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
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
    [ProducesResponseType(typeof(FindOneResponse<CreateCallsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
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
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task Delete(Guid id)
    {
        await callsService.Delete(id);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
