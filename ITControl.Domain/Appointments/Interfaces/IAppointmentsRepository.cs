using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Shared;

namespace ITControl.Domain.Appointments.Interfaces;

public interface IAppointmentsRepository : IRepository<Appointment>
{
}