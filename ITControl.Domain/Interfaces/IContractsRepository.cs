using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IContractsRepository
{
    Task<Contract?> FindOneAsync(
        Guid id, 
        bool? includeContractsContacts = null);
    Task<IEnumerable<Contract>> FindManyAsync(
        string? objectValue = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        string? orderByObject = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Contract contract);
    Task UpdateAsync(Contract contract);
    Task DeleteAsync(Contract contract);
    Task<int> CountAsync(
        Guid? id = null,
        string? objectValue = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? objectValue = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? objectValue = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null);
}