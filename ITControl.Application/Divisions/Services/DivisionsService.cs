using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Divisions.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division> FindOneAsync(FindOneDivisionsRepositoryParams @params)
    {
        return await unitOfWork.DivisionsRepository.FindOneAsync(@params)
               ?? throw new NotFoundException(Errors.DIVISION_NOT_FOUND);
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRepositoryParams @params)
    {
        return await unitOfWork.DivisionsRepository.FindManyAsync(@params);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRepositoryParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.DivisionsRepository.CountAsync(@params);
        
        var pagination = Pagination.Build(
            @params.Page.ToString() ?? "", @params.Size.ToString() ?? "", count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(Division division)
    {
         await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(Guid id, UpdateDivisionParams @params)
    {
        var division = await FindOneAsync(new () { Id = id });
        division.Update(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var division = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
        await unitOfWork.Commit(transaction);
    }
}