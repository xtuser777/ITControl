using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;
[Route("notifications-references")]
[ApiController]
public class NotificationsReferencesController(
    INotificationsReferencesView notificationsReferencesView) : ControllerBase
{
    [HttpGet]
    public FindManyResponse<TranslatableField> Index()
    {
        var data = notificationsReferencesView.FindMany();
        return new FindManyResponse<TranslatableField>()
        {
            Data = data
        };
    }
}
