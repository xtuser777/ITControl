using ITControl.Application.Positions.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Positions.Entities;

namespace ITControl.Application.Positions.Interfaces;

public interface IPositionsService
{
    Task<Position> FindOneAsync(FindOnePositionsServiceParams @params);
    Task<IEnumerable<Position>> FindManyAsync(
        FindManyPositionsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationPositionsServiceParams @params);
    Task<Position?> CreateAsync(CreatePositionsServiceParams @params);
    Task UpdateAsync(UpdatePositionsServiceParams @params);
    Task DeleteAsync(DeletePositionsServiceParams @params);
}