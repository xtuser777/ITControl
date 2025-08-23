using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IContractsRepository
{
    Task<Contract?> FindOneAsync(
        Guid id, 
        bool? includeContractsContacts = null);
    Task<IEnumerable<Contract>> FindManyAsync(
        string? objectName = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        string? orderByObjectName = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Contract contract);
    void Update(Contract contract);
    void Delete(Contract contract);
    Task<int> CountAsync(
        Guid? id = null,
        string? objectName = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? objectName = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? objectName = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
}