using ITControl.Communication.Shared.Responses;
using ITControl.Communication.SupplementsMovements.Requests;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsService
{
    Task<SupplementMovement> FindOneAsync(
        Guid id, bool? includeSupplement = null, bool? includeUser = null, 
        bool? includeUnit = null, bool? includeDepartment = null, bool? includeDivision = null);
    Task<IEnumerable<SupplementMovement>> FindManyAsync(FindManySupplementsMovementsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManySupplementsMovementsRequest request);
    Task<SupplementMovement> CreateAsync(CreateSupplementsMovementsRequest request);
    Task DeleteAsync(Guid id);
}
