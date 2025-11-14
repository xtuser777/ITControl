using ITControl.Application.Shared.Params;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Appointments.Interfaces;

public interface IAppointmentsService
{
    Task<Appointment> FindOneAsync(
        FindOneServiceParams @params);
    Task<IEnumerable<Appointment>> FindManyAsync(
        FindManyServiceParams @params);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams @params);
    Task<Appointment?> CreateAsync(CreateServiceParams @params);
    Task UpdateAsync(UpdateServiceParams @params);
    Task DeleteAsync(DeleteServiceParams @params);
    Task CheckTodaysAsync(Guid userId);
}