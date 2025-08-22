using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IAppointmentsService
{
    Task<Appointment> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeCall = null,
        bool? includeLocation = null);
    Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyAppointmentsRequest request);
    Task<Appointment?> CreateAsync(CreateAppointmentsRequest request);
    Task UpdateAsync(Guid id, UpdateAppointmentsRequest request);
    Task DeleteAsync(Guid id);
}