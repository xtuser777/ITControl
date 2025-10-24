using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;

namespace ITControl.Application.Contracts.Interfaces;

public interface IContractsService
{
    Task<Contract> FindOneAsync(
        FindOneServiceParams findOneParams);
    Task<IEnumerable<Contract>> FindManyAsync(
        FindManyServiceParams findManyParams);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams findManyParams);
    Task<Contract?> CreateAsync(
        CreateServiceParams createParams);
    Task UpdateAsync(
        UpdateServiceParams updateParams);
    Task DeleteAsync(
        DeleteServiceParams deleteParams);
}