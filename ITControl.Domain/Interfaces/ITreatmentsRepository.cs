using ITControl.Domain.Entities;
using ITControl.Domain.Enums;

namespace ITControl.Domain.Interfaces;

public interface ITreatmentsRepository
{
    Task<Treatment?> FindOneAsync(
        Guid id,
        bool? includeCall = null,
        bool? includeUser = null);
    Task<IEnumerable<Treatment>> FindManyAsync(
        string? description = null,
        string? protocol = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        TimeOnly? startedIn = null,
        TimeOnly? endedIn = null,
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        string? observation = null,
        string? externalProtocol = null,
        Guid? callId = null,
        Guid? userId = null,
        string? orderByDescription = null,
        string? orderByProtocol = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null,
        string? orderByStartedIn = null,
        string? orderByEndedIn = null,
        string? orderByStatus = null,
        string? orderByType = null,
        string? orderByObservation = null,
        string? orderByExternalProtocol = null,
        string? orderByCall = null,
        string? orderByUser = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Treatment treatment);
    void Update(Treatment treatment);
    void Delete(Treatment treatment);
    Task<int> CountAsync(
        Guid? id = null,
        string? description = null,
        string? protocol = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        TimeOnly? startedIn = null,
        TimeOnly? endedIn = null,
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        string? observation = null,
        string? externalProtocol = null,
        Guid? callId = null,
        Guid? userId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? description = null,
        string? protocol = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        TimeOnly? startedIn = null,
        TimeOnly? endedIn = null,
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        string? observation = null,
        string? externalProtocol = null,
        Guid? callId = null,
        Guid? userId = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? protocol = null);
}