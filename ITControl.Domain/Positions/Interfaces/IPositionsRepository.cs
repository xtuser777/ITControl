using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Params;

namespace ITControl.Domain.Positions.Interfaces;

public interface IPositionsRepository
{
    Task<Position?> FindOneAsync(FindOnePositionRepositoryParams @params);
    Task<IEnumerable<Position>> FindManyAsync(FindManyPositionsRepositoryParams @params);
    Task CreateAsync(Position position);
    void Update(Position position);
    void Delete(Position position);
    Task<int> CountAsync(CountPositionsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsPositionsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusivePositionsRepositoryParams @params);
}