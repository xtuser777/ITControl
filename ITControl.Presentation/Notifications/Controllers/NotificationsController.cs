using ITControl.Application.Notifications.Interfaces;
using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Notifications.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Controllers;

[Route("[controller]")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NotificationsController(
    INotificationsService notificationsService,
    INotificationsView notificationsView) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FindManyResponse<FindManyNotificationsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindManyResponse<FindManyNotificationsResponse>> IndexAsync(
        [FromQuery] FindManyNotificationsRequest request)
    {
        var notifications = await notificationsService.FindManyAsync(request);
        var response = new FindManyResponse<FindManyNotificationsResponse>
        {
            Data = notificationsView.FindMany(notifications)
        };
        var pagination = await notificationsService.FindManyPaginationAsync(request);
        if (pagination != null)
        {
            response.Pagination = pagination;
        }
        return response;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FindOneResponse<FindOneNotificationsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<FindOneNotificationsResponse?>> ShowAsync([FromRoute] Guid id)
    {
        var notification = await notificationsService.FindOneAsync(
            id, true, true, true, true);
        var response = new FindOneResponse<FindOneNotificationsResponse?>
        {
            Data = notificationsView.FindOne(notification)
        };
        return response;
    }

    [HttpGet("count-unread/{userId:guid}")]
    [ProducesResponseType(typeof(FindOneResponse<CountUnreadNotificationsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<FindOneResponse<CountUnreadNotificationsResponse>> CountUnreadAsync([FromRoute] Guid userId)
    {
        var count = await notificationsService.CountUnreadAsync(userId);
        var response = new FindOneResponse<CountUnreadNotificationsResponse>
        {
            Data = notificationsView.CountUnread(count)
        };
        return response;
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] Guid id, 
        [FromBody] UpdateNotificationsRequest request)
    {
        await notificationsService.UpdateAsync(id, request);
        return NoContent();
    }
}
