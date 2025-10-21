using ITControl.Application.Contracts.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;

namespace ITControl.Application.Contracts.Interfaces;

public interface IContractsService
{
    Task<Contract> FindOneAsync(
        FindOneContractsServiceParams findOneParams);
    Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsServiceParams findManyParams);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationContractsServiceParams findManyParams);
    Task<Contract?> CreateAsync(
        CreateContractsServiceParams createParams);
    Task UpdateAsync(
        UpdateContractsServiceParams updateParams);
    Task DeleteAsync(
        DeleteContractsServiceParams deleteParams);
}