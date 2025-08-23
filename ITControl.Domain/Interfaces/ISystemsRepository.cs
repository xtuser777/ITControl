namespace ITControl.Domain.Interfaces;

public interface ISystemsRepository
{
    Task<Entities.System?> FindOneAsync(
        Guid id, bool? includeContract = null);
    Task<IEnumerable<Entities.System>> FindManyAsync(
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null,
        string? orderByName = null,
        string? orderByVersion = null,
        string? orderByImplementedAt = null,
        string? orderByEndedAt = null,
        string? orderByOwn = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Entities.System system);
    void Update(Entities.System system);
    void Delete(Entities.System system);
    Task<int> CountAsync(
        Guid? id = null,
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null);
}