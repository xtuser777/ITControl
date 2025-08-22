using ITControl.Communication.Appointments.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IAppointmentsView
{
    CreateAppointmentsResponse? Create(Appointment? appointment);
    FindOneAppointmentsResponse? FindOne(Appointment? appointment);
    IEnumerable<FindManyAppointmentsResponse> FindMany(IEnumerable<Appointment>? appointments);
}