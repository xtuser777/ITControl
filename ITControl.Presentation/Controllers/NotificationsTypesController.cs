using ITControl.Application.Notifications.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;
[Route("notifications-types")]
[ApiController]
public class NotificationsTypesController(
    INotificationsTypesView notificationsTypesView) : ControllerBase
{
    [HttpGet]
    public FindManyResponse<TranslatableField> Index()
    {
        var data = notificationsTypesView.FindMany();
        return new FindManyResponse<TranslatableField>()
        {
            Data = data
        };
    }
}
