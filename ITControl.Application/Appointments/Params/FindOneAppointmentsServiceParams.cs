using ITControl.Domain.Appointments.Params;

namespace ITControl.Application.Appointments.Params;

public record FindOneAppointmentsServiceParams
{
    public Guid Id { get; set; }
    public IncludesAppointmentsParams? Includes { get; set; } = null;

    public static implicit operator FindOneAppointmentsRepositoryParams(
        FindOneAppointmentsServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
            Includes = serviceParams.Includes
        };
}
