namespace ITControl.Communication.Appointments.Responses;

public class FindOneAppointmentsCallUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string? Division { get; set; }
}