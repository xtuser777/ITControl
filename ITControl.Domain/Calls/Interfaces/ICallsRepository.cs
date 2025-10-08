using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Calls.Params;

namespace ITControl.Domain.Calls.Interfaces;

public interface ICallsRepository
{
    Task<Call?> FindOneAsync(FindOneCallsRepositoryParams @params);
    Task<IEnumerable<Call>> FindManyAsync(FindManyCallsRepositoryParams @params);
    Task CreateAsync(Call call);
    void Update(Call call);
    void Delete(Call call);
    Task<int> CountAsync(CountCallsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsCallsRepositoryParams @params);
}

