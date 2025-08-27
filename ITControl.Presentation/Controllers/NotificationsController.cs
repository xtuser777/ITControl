using ITControl.Application.Interfaces;
using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Notifications.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("notifications")]
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
        var notifications = await notificationsService.FindMany(request);
        var response = new FindManyResponse<FindManyNotificationsResponse>
        {
            Data = notificationsView.FindMany(notifications)
        };
        var pagination = await notificationsService.FindManyPagination(request);
        if (pagination != null)
        {
            response.Pagination = pagination;
        }
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
        await notificationsService.Update(id, request);
        return NoContent();
    }
}
