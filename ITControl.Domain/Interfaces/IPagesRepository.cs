using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IPagesRepository
{
    Task<Page?> FindOneAsync(Guid id);
    Task<IEnumerable<Page>> FindManyAsync(string? name = null, string? orderByName = null, int? page = null, int? size = null);
    Task CreateAsync(Page page);
    Task UpdateAsync(Page page);
    Task DeleteAsync(Page page);
    Task<int> CountAsync(Guid? id = null, string? name = null);
    Task<bool> ExistAsync(Guid? id = null, string? name = null);
    Task<bool> ExclusiveAsync(Guid id, string? name = null);
}