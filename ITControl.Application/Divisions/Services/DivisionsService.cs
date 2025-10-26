using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Divisions.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.DivisionsRepository
                   .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.DIVISION_NOT_FOUND);
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.DivisionsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.DivisionsRepository
            .CountAsync(parameters.CountParams);
        var pagination = Pagination.Build(
            parameters.PaginationParams, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var division = new Division((DivisionParams)parameters.Params);
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var division = await FindOneAsync(parameters);
        division.Update((UpdateDivisionParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var division = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
        await unitOfWork.Commit(transaction);
    }
}