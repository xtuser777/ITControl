using ITControl.Presentation.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Controllers;
[Route("notifications-references")]
[ApiController]
public class NotificationsReferencesController(
    INotificationsReferencesView notificationsReferencesView) : ControllerBase
{
    [HttpGet]
    public Shared.Responses.FindManyResponse<TranslatableField> Index()
    {
        var data = notificationsReferencesView.FindMany();
        return new Shared.Responses.FindManyResponse<TranslatableField>()
        {
            Data = data
        };
    }
}
