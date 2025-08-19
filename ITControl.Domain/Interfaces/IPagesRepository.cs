using ITControl.Domain.Entities;
using System.Linq.Expressions;

namespace ITControl.Domain.Interfaces;

public interface IPagesRepository
{
    Task<Page?> FindOneAsync(Expression<Func<Page?, bool>> predicate);
    Task<IEnumerable<Page>> FindManyAsync(
        string? name = null, string? orderByName = null, int? page = null, int? size = null);
    Task CreateAsync(Page page);
    void Update(Page page);
    void Delete(Page page);
    Task<int> CountAsync(Guid? id = null, string? name = null);
    Task<bool> ExistAsync(Guid? id = null, string? name = null);
    Task<bool> ExclusiveAsync(Guid id, string? name = null);
}