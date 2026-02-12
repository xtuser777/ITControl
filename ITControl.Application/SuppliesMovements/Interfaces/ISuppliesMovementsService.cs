using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.SuppliesMovements.Entities;

namespace ITControl.Application.SuppliesMovements.Interfaces;

public interface ISuppliesMovementsService
{
    Task<SupplyMovement> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<SupplyMovement>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<SupplyMovement> CreateAsync(
        CreateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}
