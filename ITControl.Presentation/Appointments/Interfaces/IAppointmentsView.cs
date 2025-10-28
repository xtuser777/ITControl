using ITControl.Domain.Appointments.Entities;
using ITControl.Presentation.Appointments.Responses;

namespace ITControl.Presentation.Appointments.Interfaces;

public interface IAppointmentsView
{
    CreateAppointmentsResponse? Create(Appointment? appointment);
    FindOneAppointmentsResponse? FindOne(Appointment? appointment);
    IEnumerable<FindManyAppointmentsResponse> FindMany(IEnumerable<Appointment>? appointments);
}