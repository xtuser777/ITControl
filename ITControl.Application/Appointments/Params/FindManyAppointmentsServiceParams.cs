using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Appointments.Params;

public record FindManyAppointmentsServiceParams
{
    public FindManyAppointmentsRepositoryParams FindManyParams { get; set; } = new();
    public OrderByAppointmentsRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}
