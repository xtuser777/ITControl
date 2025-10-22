using ITControl.Application.SupplementsMovements.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsService
{
    Task<SupplementMovement> FindOneAsync(
        FindOneSupplementsMovementsServiceParams @params);
    Task<IEnumerable<SupplementMovement>> FindManyAsync(
        FindManySupplementsMovementsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationSupplementsMovementsServiceParams @params);
    Task<SupplementMovement> CreateAsync(
        CreateSupplementsMovementsServiceParams @params);
    Task DeleteAsync(DeleteSupplementsMovementsServiceParams @params);
}
