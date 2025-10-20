namespace ITControl.Application.Appointments.Params;

public record DeleteAppointmentsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneAppointmentsServiceParams(
        DeleteAppointmentsServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
            Includes = null
        };
}
