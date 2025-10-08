using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Appointments.Entities;

namespace ITControl.Application.Appointments.Interfaces;

public interface IAppointmentsService
{
    Task<Appointment> FindOneAsync(FindOneAppointmentsRequest request);
    Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyAppointmentsRequest request);
    Task<Appointment?> CreateAsync(CreateAppointmentsRequest request);
    Task UpdateAsync(Guid id, UpdateAppointmentsRequest request);
    Task DeleteAsync(Guid id);
}