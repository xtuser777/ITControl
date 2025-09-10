using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Calls.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Controllers;
[Route("calls")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CallsController(
    ICallsService callsService,
    ICallsView callsView,
    IWebSocketService webSocketService,
    INotificationsService notificationsService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FindManyResponse<FindManyCallsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindManyResponse<FindManyCallsResponse>> IndexAsync(
        [FromQuery] FindManyCallsRequest request)
    {
        var calls = await callsService.FindManyAsync(request);
        var pagination = await callsService.FindManyPaginationAsync(request);
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
    public async Task<FindOneResponse<FindOneCallsResponse?>> ShowAsync(Guid id)
    {
        var call = await callsService.FindOneAsync(id, true, true, true, true);
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
    public async Task<FindOneResponse<CreateCallsResponse?>> CreateAsync(
        [FromBody] CreateCallsRequest request)
    {
        var call = await callsService.CreateAsync(request);
        var data = callsView.Create(call);
        if (call != null)
        {
            var count = await notificationsService.CountUnreadAsync(call.UserId);
            await webSocketService.EchoAsync(call.UserId.ToString(), count.ToString());
        }
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
    public async Task DeleteAsync(Guid id)
    {
        await callsService.DeleteAsync(id);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
