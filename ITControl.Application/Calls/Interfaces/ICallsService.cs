using ITControl.Application.Calls.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;

namespace ITControl.Application.Calls.Interfaces;
public interface ICallsService
{
    Task<Call> FindOneAsync(FindOneCallsServiceParams @params);
    Task<IEnumerable<Call>> FindManyAsync(
        FindManyCallsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationCallsServiceParams @params);
    Task<Call?> CreateAsync(CreateCallsServiceParams @params);
    Task DeleteAsync(DeleteCallsServiceParams @params);
}
