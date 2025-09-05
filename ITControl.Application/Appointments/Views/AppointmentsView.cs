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
            LocationId = appointment.LocationId,
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
                    User = appointment.Call.User?.Name ?? ""
                }
                : null,
            Location = appointment.Location != null
                ? new FindOneAppointmentsLocationResponse()
                {
                    Id = appointment.Location.Id,
                    Description = appointment.Location.Description,
                    Unit = appointment.Location.Unit?.Name ?? "",
                    Address = $"{appointment.Location.Unit?.StreetName}, {appointment.Location.Unit?.AddressNumber}, {appointment.Location.Unit?.Neighborhood}",
                    Phone = appointment.Location.Unit?.Phone ?? "",
                    Department = appointment.Location.Department?.Name ?? "",
                    Division = appointment.Location.Division?.Name ?? "",
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
                LocationId = appointment.LocationId,
            };
    }
}