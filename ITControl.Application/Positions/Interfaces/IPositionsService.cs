using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Positions.Entities;

namespace ITControl.Application.Positions.Interfaces;

public interface IPositionsService
{
    Task<Position> FindOneAsync(FindOnePositionsRequest request);
    Task<IEnumerable<Position>> FindManyAsync(
        FindManyPositionsRequest request,
        OrderByPositionsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPositionsRequest request);
    Task<Position?> CreateAsync(CreatePositionsRequest request);
    Task UpdateAsync(Guid id, UpdatePositionsRequest request);
    Task DeleteAsync(Guid id);
}