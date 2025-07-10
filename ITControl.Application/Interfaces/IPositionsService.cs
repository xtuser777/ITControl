using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPositionsService
{
    Task<IEnumerable<Position>> FindMany(FindManyPositionsRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManyPositionsRequest request);
    Task<Position?> FindOne(Guid id);
    Task<Position?> Create(CreatePositionsRequest request);
    Task Update(Guid id, UpdatePositionsRequest request);
    Task Delete(Guid id);
}