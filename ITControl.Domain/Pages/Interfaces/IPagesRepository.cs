using ITControl.Domain.Pages.Entities;

namespace ITControl.Domain.Pages.Interfaces;

public interface IPagesRepository
{
    Task<Page?> FindOneAsync(IFindOnePagesRepositoryParams @params);
    Task<IEnumerable<Page>> FindManyAsync(IFindManyPagesRepositoryParams @params);
    Task CreateAsync(Page page);
    void Update(Page page);
    void Delete(Page page);
    Task<int> CountAsync(ICountPagesRepositoryParams @params);
    Task<bool> ExistsAsync(IExistsPagesRepositoryParams @params);
    Task<bool> ExclusiveAsync(IExclusivePagesRepositoryParams @params);
}

public interface IFindOnePagesRepositoryParams
{
    Guid? Id { get; set; }
}

public interface IFindManyPagesRepositoryParams
{
    string? Name { get; set; }
    string? OrderByName { get; set; }
    int? Page { get; set; }
    int? Size { get; set; }
}

public interface ICountPagesRepositoryParams
{
    Guid? Id { get; set; }
    string? Name { get; set; }
}

public interface IExistsPagesRepositoryParams : ICountPagesRepositoryParams { }

public interface IExclusivePagesRepositoryParams
{
    Guid Id { get; set; }
    string? Name { get; set; }
}