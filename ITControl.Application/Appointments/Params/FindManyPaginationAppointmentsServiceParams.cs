using ITControl.Domain.Appointments.Params;

namespace ITControl.Application.Appointments.Params;

public record FindManyPaginationAppointmentsServiceParams
{
    public CountAppointmentsRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;
}
