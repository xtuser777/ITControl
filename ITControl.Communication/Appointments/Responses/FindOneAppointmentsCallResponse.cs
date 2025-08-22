namespace ITControl.Communication.Appointments.Responses;

public class FindOneAppointmentsCallResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
}