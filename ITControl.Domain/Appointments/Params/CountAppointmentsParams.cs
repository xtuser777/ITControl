namespace ITControl.Domain.Appointments.Params;

public record CountAppointmentsParams :
    FindManyAppointmentsParams
{
    public Guid? Id { get; set; } = null;
}
