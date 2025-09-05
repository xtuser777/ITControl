using ITControl.Communication.Appointments.Responses;
using ITControl.Domain.Appointments.Entities;

namespace ITControl.Application.Appointments.Interfaces;

public interface IAppointmentsView
{
    CreateAppointmentsResponse? Create(Appointment? appointment);
    FindOneAppointmentsResponse? FindOne(Appointment? appointment);
    IEnumerable<FindManyAppointmentsResponse> FindMany(IEnumerable<Appointment>? appointments);
}