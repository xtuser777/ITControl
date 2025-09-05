using ITControl.Domain.Appointments.Entities;

namespace ITControl.Domain.Appointments.Interfaces;

public interface IAppointmentsRepository
{
    Task<Appointment?> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeCall = null,
        bool? includeLocation = null);
    Task<IEnumerable<Appointment>> FindManyAsync(
        string? description = null,
        DateOnly? scheduledAt = null,
        TimeOnly? scheduledIn = null,
        string? observation = null,
        Guid? userId = null,
        Guid? callId = null,
        Guid? locationId = null,
        string? orderByDescription = null,
        string? orderByStartedAt = null,
        string? orderByStartedIn = null,
        string? orderByObservation = null,
        string? orderByUser = null,
        string? orderByCall = null,
        string? orderByLocation = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Appointment appointment);
    void Update(Appointment appointment);
    void Delete(Appointment appointment);
    Task<int> CountAsync(
        Guid? id = null,
        string? description = null,
        DateOnly? scheduledAt = null,
        TimeOnly? scheduledIn = null,
        string? observation = null,
        Guid? userId = null,
        Guid? callId = null,
        Guid? locationId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? description = null,
        DateOnly? scheduledAt = null,
        TimeOnly? scheduledIn = null,
        string? observation = null,
        Guid? userId = null,
        Guid? callId = null,
        Guid? locationId = null);
}