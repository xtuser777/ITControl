using ITControl.Domain.Appointments.Params;

namespace ITControl.Application.Appointments.Params;

public record UpdateAppointmentsServiceParams
{
    public Guid Id { get; set; }
    public UpdateAppointmentParams Params { get; set; } = new();

    public static implicit operator FindOneAppointmentsServiceParams(
        UpdateAppointmentsServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
            Includes = new IncludesAppointmentsParams { User = true, Call = true }
        };
}
