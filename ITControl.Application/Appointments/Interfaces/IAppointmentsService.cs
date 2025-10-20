using ITControl.Application.Appointments.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Appointments.Entities;

namespace ITControl.Application.Appointments.Interfaces;

public interface IAppointmentsService
{
    Task<Appointment> FindOneAsync(
        FindOneAppointmentsServiceParams @params);
    Task<IEnumerable<Appointment>> FindManyAsync(
        FindManyAppointmentsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationAppointmentsServiceParams @params);
    Task<Appointment?> CreateAsync(CreateAppointmentsServiceParams @params);
    Task UpdateAsync(UpdateAppointmentsServiceParams @params);
    Task DeleteAsync(DeleteAppointmentsServiceParams @params);
}