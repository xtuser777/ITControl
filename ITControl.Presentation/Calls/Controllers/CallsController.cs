using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Communication.Calls.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Calls.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Controllers;
[Route("[controller]")]
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
    [ProducesResponseType(
        typeof(FindManyResponse<FindManyCallsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexCallsParams @params)
    {
        var calls = await callsService.FindManyAsync(@params);
        var pagination = await callsService.FindManyPaginationAsync(@params);
        var data = callsView.FindMany(calls);
        return Ok(new { Data = data, Pagination = pagination });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneCallsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowCallsParams @params)
    {
        var call = await callsService.FindOneAsync(@params);
        var data = callsView.FindOne(call);
        return Ok(new { Data = data });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateCallsResponse?>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateCallsParams @params)
    {
        var call = await callsService.CreateAsync(@params);
        var data = callsView.Create(call);
        if (call != null)
        {
            var count = await notificationsService.CountUnreadAsync(call.UserId);
            await webSocketService.EchoAsync(call.UserId.ToString(), count.ToString());
        }
        var url = $"/calls/{data?.Id}";
        return Created(url, new { Data = data });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteCallsParams @params)
    {
        await callsService.DeleteAsync(@params);
        return NoContent();
    }
}
