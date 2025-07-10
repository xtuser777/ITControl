using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IPositionsRepository
{
    Task<Position?> FindOneAsync(Guid id);
    Task<IEnumerable<Position>> FindManyAsync(string? description = null, string? orderByDescription = null, int? page = null, int? size = null);
    Task CreateAsync(Position position);
    Task UpdateAsync(Position position);
    Task DeleteAsync(Position position);
    Task<int> CountAsync(Guid? id = null, string? description = null);
    Task<bool> ExistAsync(Guid? id = null, string? description = null);
    Task<bool> ExclusiveAsync(Guid id, string? description = null);
}