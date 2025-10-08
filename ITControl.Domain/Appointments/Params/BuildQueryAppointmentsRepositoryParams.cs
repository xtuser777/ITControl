using ITControl.Domain.Appointments.Entities;

namespace ITControl.Domain.Appointments.Params;

public class BuildQueryAppointmentsRepositoryParams
{
    public IQueryable<Appointment> Query { get; set; } = null!;
    public CountAppointmentsRepositoryParams Params { get; set; } = null!;
    public void Deconstruct(
        out IQueryable<Appointment> query,
        out CountAppointmentsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
