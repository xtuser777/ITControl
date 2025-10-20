using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record CountAppointmentsRepositoryParams :
    FindManyAppointmentsRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
