using ITControl.Domain.Pages.Entities;

namespace ITControl.Domain.Pages.Interfaces;

public interface IPagesRepository
{
    Task<Page?> FindOneAsync(Guid id);
    Task<IEnumerable<Page>> FindManyAsync(
        string? name = null, string? orderByName = null, int? page = null, int? size = null);
    Task CreateAsync(Page page);
    void Update(Page page);
    void Delete(Page page);
    Task<int> CountAsync(Guid? id = null, string? name = null);
    Task<bool> ExistsAsync(Guid? id = null, string? name = null);
    Task<bool> ExclusiveAsync(Guid id, string? name = null);
}