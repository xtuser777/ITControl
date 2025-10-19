using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Divisions.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division> FindOneAsync(FindOneDivisionsRequest request)
    {
        return (Division)(await unitOfWork.DivisionsRepository.FindOneAsync(
                   (FindOneDivisionsRepositoryParams)request))!
               ?? throw new NotFoundException(Errors.DIVISION_NOT_FOUND);
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(
        FindManyDivisionsRequest request,
        OrderByDivisionsRequest orderByDivisionsRequest)
    {
        var entities = await unitOfWork.DivisionsRepository.FindManyAsync(
            (FindManyDivisionsRepositoryParams)request,
            (OrderByDivisionsRepositoryParams)orderByDivisionsRequest,
            request);

        return entities.Cast<Division>();
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.DivisionsRepository.CountAsync(
            (CountDivisionsRepositoryParams)request);
        
        var pagination = Pagination.Build(
            request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(CreateDivisionsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var division = new Division(request);
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(UpdateDivisionsRequest request)
    {
        var division = await FindOneAsync(request);
        division.Update(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteDivisionsRequest request)
    {
        var division = await FindOneAsync(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
        await unitOfWork.Commit(transaction);
    }
}