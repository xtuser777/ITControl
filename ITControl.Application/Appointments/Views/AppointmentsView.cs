using ITControl.Application.Appointments.Interfaces;
using ITControl.Communication.Appointments.Responses;
using ITControl.Domain.Appointments.Entities;

namespace ITControl.Application.Appointments.Views;

public class AppointmentsView : IAppointmentsView
{
    public CreateAppointmentsResponse? Create(Appointment? appointment)
    {
        if (appointment == null) return null;

        return new CreateAppointmentsResponse()
        {
            Id = appointment.Id,
        };
    }

    public FindOneAppointmentsResponse? FindOne(Appointment? appointment)
    {
        if (appointment == null) return null;

        return new FindOneAppointmentsResponse()
        {
            Id = appointment.Id,
            Description = appointment.Description,
            ScheduledAt = appointment.ScheduledAt,
            ScheduledIn = appointment.ScheduledIn,
            Observation = appointment.Observation,
            UserId = appointment.UserId,
            CallId = appointment.CallId,
            User = appointment.User != null
                ? new FindOneAppointmentsUserResponse()
                {
                    Id = appointment.User.Id,
                    Name = appointment.User.Name,
                }
                : null,
            Call = appointment.Call != null
                ? new FindOneAppointmentsCallResponse()
                {
                    Id = appointment.Call.Id,
                    Title = appointment.Call.Title,
                    Description = appointment.Call.Description,
                    User = new FindOneAppointmentsCallUserResponse()
                    {
                        Id = appointment.User!.Id,
                        Name = appointment.User.Name,
                        Unit = appointment.User.Unit?.Name ?? "",
                        Address = $"{appointment.User.Unit?.StreetName}, {appointment.User.Unit?.AddressNumber}, {appointment.User.Unit?.Neighborhood}",
                        Phone = appointment.User.Unit?.Phone ?? "",
                        Department = appointment.User.Department?.Name ?? "",
                        Division = appointment.User.Division?.Name ?? "",
                    }
                }
                : null,
        };
    }

    public IEnumerable<FindManyAppointmentsResponse> FindMany(IEnumerable<Appointment>? appointments)
    {
        if (appointments == null) return [];

        return from appointment in appointments
            select new FindManyAppointmentsResponse()
            {
                Id = appointment.Id,
                Description = appointment.Description,
                ScheduledAt = appointment.ScheduledAt,
                ScheduledIn = appointment.ScheduledIn,
                Observation = appointment.Observation,
                UserId = appointment.UserId,
                CallId = appointment.CallId,
            };
    }
}