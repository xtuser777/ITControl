using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Interfaces;

public interface IPagesRepository
{
    Task<Page?> FindOneAsync(FindOnePagesRepositoryParams @params);
    Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesRepositoryParams findManyParams,
        OrderByPagesRepositoryParams orderByParams,
        PaginationParams paginationParams);
    Task CreateAsync(Page page);
    void Update(Page page);
    void Delete(Page page);
    Task<int> CountAsync(CountPagesRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsPagesRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusivePagesRepositoryParams @params);
}