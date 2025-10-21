using ITControl.Application.Notifications.Interfaces;
using ITControl.Communication.Notifications.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Notifications.Params;
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
    [ProducesResponseType(
        typeof(FindManyResponse<FindManyNotificationsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexNotificationsParams @params)
    {
        var notifications = 
            await notificationsService.FindManyAsync(@params);
        var pagination = 
            await notificationsService.FindManyPaginationAsync(@params);
        var response = new 
        {
            Data = notificationsView.FindMany(notifications),
            Pagination = pagination
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneNotificationsResponse?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowNotificationsParams @params)
    {
        var notification = await notificationsService.FindOneAsync(@params);
        var response = new FindOneResponse<FindOneNotificationsResponse?>
        {
            Data = notificationsView.FindOne(notification)
        };
        return Ok(response);
    }

    [HttpGet("count-unread/{userId:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<CountUnreadNotificationsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CountUnreadAsync([FromRoute] Guid userId)
    {
        var count = await notificationsService.CountUnreadAsync(userId);
        var response = new FindOneResponse<CountUnreadNotificationsResponse>
        {
            Data = notificationsView.CountUnread(count)
        };
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateNotificationsParams @params)
    {
        await notificationsService.UpdateAsync(@params);
        return NoContent();
    }
}
