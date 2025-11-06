using ITControl.Application.Shared.Params;
using ITControl.Presentation.Shared.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record DeleteAppointmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [ModelBinder(BinderType = typeof(UserIdAttribute))]
    public Guid UserId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteAppointmentsParams presentationParams) =>
        new()
        {
            Id = presentationParams.Id
        };
}
