using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Interfaces;

public interface IEquipmentsRepository
{
    Task<Equipment?> FindOneAsync(FindOneEquipmentsRepositoryParams @params);
    Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsRepositoryParams findManyParams,
        OrderByEquipmentsRepositoryParams orderByParams,
        PaginationParams paginationParams);
    Task CreateAsync(Equipment equipment);
    void Update(Equipment equipment);
    void Delete(Equipment equipment);
    Task<int> CountAsync(CountEquipmentsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsEquipmentsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveEquipmentsRepositoryParams @params);
}