using ITControl.Domain.Notifications.Params;

namespace ITControl.Communication.Notifications.Requests;

public record FindOneNotificationsRequest
{
    public Guid Id { get; set; }
    public bool? IncludeUser { get; set; } = true;
    public bool? IncludeCall { get; set; } = true;
    public bool? IncludeAppointment { get; set; } = true;
    public bool? IncludeTreatment { get; set; } = true;

    public static implicit operator FindOneNotificationsRepositoryParams(FindOneNotificationsRequest request)
    {
        return new FindOneNotificationsRepositoryParams
        {
            Id = request.Id,
            Includes = new IncludesNotificationsParams
            {
                User = request.IncludeUser,
                Call = request.IncludeCall,
                Appointment = request.IncludeAppointment,
                Treatment = request.IncludeTreatment,
            }
        };
    }
}
