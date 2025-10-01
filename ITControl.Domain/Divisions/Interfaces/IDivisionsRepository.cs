using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Params;

namespace ITControl.Domain.Divisions.Interfaces;

public interface IDivisionsRepository
{
    Task<Division?> FindOneAsync(FindOneDivisionsRepositoryParams @params);
    Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRepositoryParams @params);
    Task CreateAsync(Division division);
    void Update(Division division);
    void Delete(Division division);
    Task<int> CountAsync(CountDivisionsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsDivisionsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveDivisionsRepositoryParams @params);
}