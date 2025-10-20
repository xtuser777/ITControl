using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record IncludesAppointmentsParams : IncludesParams
{
    public bool User { get; set; } = false;
    public bool Call { get; set; } = false;
}
