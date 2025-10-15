using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Units.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Units.Requests;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Units.Entities;

namespace ITControl.Application.Units.Services;

public class UnitsService(IUnitOfWork unitOfWork) : IUnitsService
{
    public async Task<Unit> FindOneAsync(FindOneUnitsRequest request)
    {
        return await unitOfWork.UnitsRepository.FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.UNIT_NOT_FOUND);
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
        FindManyUnitsRequest request,
        OrderByUnitsRequest orderByRequest)
    {
        return await unitOfWork.UnitsRepository.FindManyAsync(
            request, orderByRequest, request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyUnitsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.UnitsRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Unit?> CreateAsync(CreateUnitsRequest request)
    {
        var unit = new Unit(request);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UnitsRepository.CreateAsync(unit);
        await unitOfWork.Commit(transaction);

        return unit;
    }

    public async Task UpdateAsync(Guid id, UpdateUnitsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var unit = await FindOneAsync(new() { Id = id });
        unit.Update(request);
        unitOfWork.UnitsRepository.Update(unit);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var unit = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Delete(unit);
        await unitOfWork.Commit(transaction);
    }
}