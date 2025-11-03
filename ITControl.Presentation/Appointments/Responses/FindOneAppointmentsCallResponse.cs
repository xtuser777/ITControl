namespace ITControl.Presentation.Appointments.Responses;

public class FindOneAppointmentsCallResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public FindOneAppointmentsCallUserResponse? User { get; set; }
}