using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IPositionsRepository
{
    Task<Position?> FindOneAsync(Guid id);
    Task<IEnumerable<Position>> FindManyAsync(string? description = null, string? orderByDescription = null, int? page = null, int? size = null);
    Task CreateAsync(Position position);
    void Update(Position position);
    void Delete(Position position);
    Task<int> CountAsync(Guid? id = null, string? description = null);
    Task<bool> ExistsAsync(Guid? id = null, string? description = null);
    Task<bool> ExclusiveAsync(Guid id, string? description = null);
}