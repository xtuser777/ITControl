using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsService
{
    Task<SupplementMovement> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<SupplementMovement>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<SupplementMovement> CreateAsync(
        CreateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}
