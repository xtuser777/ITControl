namespace ITControl.Domain.Appointments.Params;

public class FindOneAppointmentsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeUser { get; set; } = null;
    public bool? IncludeCall { get; set; } = null;
}
