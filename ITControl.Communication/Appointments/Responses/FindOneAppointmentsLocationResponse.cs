namespace ITControl.Communication.Appointments.Responses;

public class FindOneAppointmentsLocationResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string? Division { get; set; }
}