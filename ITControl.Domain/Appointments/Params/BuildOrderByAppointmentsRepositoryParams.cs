namespace ITControl.Domain.Appointments.Params;

public class BuildOrderByAppointmentsRepositoryParams
{
    public IQueryable<Entities.Appointment> Query { get; set; } = null!;
    public FindManyAppointmentsRepositoryParams Params { get; set; } = null!;
    public void Deconstruct(
        out IQueryable<Entities.Appointment> query,
        out FindManyAppointmentsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
