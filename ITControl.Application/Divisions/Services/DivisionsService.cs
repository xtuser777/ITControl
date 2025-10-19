using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Divisions.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Divisions.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division> FindOneAsync(
        FindOneDivisionsServiceParams @params)
    {
        return await unitOfWork.DivisionsRepository
                   .FindOneAsync(@params)
               ?? throw new NotFoundException(Errors.DIVISION_NOT_FOUND);
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(
        FindManyDivisionsServiceParams @params)
    {
        return await unitOfWork.DivisionsRepository.FindManyAsync(
            @params.FindManyParams,
            @params.OrderByParams,
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(
        FindManyPaginationDivisionsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.DivisionsRepository.CountAsync(
            @params.CountParams);
        
        var pagination = Pagination.Build(
            @params.Page, @params.Size, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(
        CreateDivisionsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var division = new Division(@params.Params);
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(UpdateDivisionsServiceParams @params)
    {
        var division = await FindOneAsync(@params);
        division.Update(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteDivisionsServiceParams @params)
    {
        var division = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
        await unitOfWork.Commit(transaction);
    }
}