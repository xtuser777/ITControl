using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Contracts.Entities;

namespace ITControl.Application.Contracts.Interfaces;

public interface IContractsService
{
    Task<Contract> FindOneAsync(
        FindOneServiceParams findOneParams);
    Task<IEnumerable<Contract>> FindManyAsync(
        FindManyServiceParams findManyParams);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams findManyParams);
    Task<Contract?> CreateAsync(
        CreateServiceParams createParams);
    Task UpdateAsync(
        UpdateServiceParams updateParams);
    Task DeleteAsync(
        DeleteServiceParams deleteParams);
}