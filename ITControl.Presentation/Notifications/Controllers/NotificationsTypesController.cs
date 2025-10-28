using ITControl.Presentation.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Controllers;
[Route("notifications-types")]
[ApiController]
public class NotificationsTypesController(
    INotificationsTypesView notificationsTypesView) : ControllerBase
{
    [HttpGet]
    public Shared.Responses.FindManyResponse<TranslatableField> Index()
    {
        var data = notificationsTypesView.FindMany();
        return new Shared.Responses.FindManyResponse<TranslatableField>()
        {
            Data = data
        };
    }
}
