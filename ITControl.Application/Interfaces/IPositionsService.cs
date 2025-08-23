using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPositionsService
{
    Task<IEnumerable<Position>> FindManyAsync(FindManyPositionsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPositionsRequest request);
    Task<Position> FindOneAsync(Guid id);
    Task<Position?> CreateAsync(CreatePositionsRequest request);
    Task UpdateAsync(Guid id, UpdatePositionsRequest request);
    Task DeleteAsync(Guid id);
}