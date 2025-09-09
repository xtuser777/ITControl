using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Interfaces;

public interface ISupplementsRepository
{
    Task<Supplement?> FindOneAsync(Guid id);
    Task<IEnumerable<Supplement>> FindManyAsync(
        string? brand = null, 
        string? model = null, 
        SupplementType? type = null,
        int? stock = null,
        string? orderByBrand = null,
        string? orderByModel = null,
        string? orderByType = null,
        string? orderByStock = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Supplement supplement);
    void Update(Supplement supplement);
    void Delete(Supplement supplement);
    Task<int> CountAsync(
        Guid? id = null,
        string? brand = null, 
        string? model = null, 
        SupplementType? type = null,
        int? stock = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? brand = null,
        string? model = null,
        SupplementType? type = null,
        int? stock = null);
}
