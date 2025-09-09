using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Supplements.Requests;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Interfaces;

public interface ISupplementsService
{
    Task<Supplement> FindOneAsync(Guid id);
    Task<IEnumerable<Supplement>> FindManyAsync(FindManySupplementsRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManySupplementsRequest request);
    Task<Supplement?> CreateAsync(CreateSupplementsRequest request);
    Task UpdateAsync(Guid id, UpdateSupplementsRequest request);
    Task DeleteAsync(Guid id);
}
