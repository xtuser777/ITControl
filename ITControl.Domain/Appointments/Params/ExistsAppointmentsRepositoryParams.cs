using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record ExistsAppointmentsRepositoryParams : 
    CountAppointmentsRepositoryParams, IExistsRepositoryParams
{
}
