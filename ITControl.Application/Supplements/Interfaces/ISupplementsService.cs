using ITControl.Application.Supplements.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Interfaces;

public interface ISupplementsService
{
    Task<Supplement> FindOneAsync(
        FindOneSupplementsServiceParams @params);
    Task<IEnumerable<Supplement>> FindManyAsync(
        FindManySupplementsServiceParams @params);
    Task<PaginationResponse?> FindManyPagination(
        FindManyPaginationSupplementsServiceParams @params);
    Task<Supplement?> CreateAsync(
        CreateSupplementsServiceParams @params);
    Task UpdateAsync(UpdateSupplementsServiceParams @params);
    Task DeleteAsync(DeleteSupplementsServiceParams @params);
}
