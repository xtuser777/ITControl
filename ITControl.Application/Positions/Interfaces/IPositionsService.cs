using ITControl.Application.Shared.Params;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Positions.Interfaces;

public interface IPositionsService
{
    Task<Position> FindOneAsync(FindOneServiceParams parameters);
    Task<IEnumerable<Position>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Position?> CreateAsync(CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}