using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;

namespace ITControl.Application.Calls.Interfaces;
public interface ICallsService
{
    Task<Call> FindOneAsync(FindOneCallsRequest request);
    Task<IEnumerable<Call>> FindManyAsync(FindManyCallsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyCallsRequest request);
    Task<Call?> CreateAsync(CreateCallsRequest request);
    Task DeleteAsync(Guid id);
}
