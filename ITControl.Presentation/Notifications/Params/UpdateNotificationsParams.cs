using ITControl.Application.Shared.Params;
using ITControl.Communication.Notifications.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Params;

public record UpdateNotificationsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody] 
    public UpdateNotificationsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateNotificationsParams param)
        => new()
        {
            Id = param.Id,
            Params = param.Request,
        };
}