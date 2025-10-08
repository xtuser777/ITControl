using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Params;

namespace ITControl.Domain.Appointments.Interfaces;

public interface IAppointmentsRepository
{
    Task<Appointment?> FindOneAsync(FindOneAppointmentsRepositoryParams @params);
    Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRepositoryParams @params);
    Task CreateAsync(Appointment appointment);
    void Update(Appointment appointment);
    void Delete(Appointment appointment);
    Task<int> CountAsync(CountAppointmentsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsAppointmentsRepositoryParams @params);
}