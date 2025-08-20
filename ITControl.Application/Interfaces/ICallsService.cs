using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;
public interface ICallsService
{
    Task<Call> FindOne(
        Guid id,
        bool? includeUser = null,
        bool? includeLocation = null,
        bool? includeEquipment = null,
        bool? includeSystem = null);
    Task<IEnumerable<Call>> FindMany(FindManyCallsRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManyCallsRequest request);
    Task<Call?> Create(CreateCallsRequest request);
    Task Delete(Guid id);
}
