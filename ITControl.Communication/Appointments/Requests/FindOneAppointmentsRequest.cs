namespace ITControl.Communication.Appointments.Requests;

public class FindOneAppointmentsRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool? IncludeCall { get; set; } = true;
    public bool? IncludeUser { get; set; } = true;

    public static implicit operator Domain.Appointments.Params.FindOneAppointmentsRepositoryParams(FindOneAppointmentsRequest request)
        => new()
        {
            Id = request.Id,
            IncludeCall = request.IncludeCall,
            IncludeUser = request.IncludeUser
        };
}
