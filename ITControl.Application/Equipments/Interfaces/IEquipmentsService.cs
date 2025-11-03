using ITControl.Application.Shared.Params;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Equipments.Interfaces;

public interface IEquipmentsService
{
    Task<Equipment> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Equipment?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}