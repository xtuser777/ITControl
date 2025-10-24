using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;

namespace ITControl.Application.Calls.Interfaces;
public interface ICallsService
{
    Task<Call> FindOneAsync(FindOneServiceParams @params);
    Task<IEnumerable<Call>> FindManyAsync(
        FindManyServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams @params);
    Task<Call?> CreateAsync(CreateServiceParams @params);
    Task DeleteAsync(DeleteServiceParams @params);
}
