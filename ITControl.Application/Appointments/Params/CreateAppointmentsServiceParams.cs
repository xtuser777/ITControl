using ITControl.Domain.Appointments.Params;

namespace ITControl.Application.Appointments.Params;

public record CreateAppointmentsServiceParams
{
    public AppointmentParams Params { get; set; } = new();
}
