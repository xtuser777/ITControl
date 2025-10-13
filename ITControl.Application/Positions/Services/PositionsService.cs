using ITControl.Application.Positions.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Positions.Entities;

namespace ITControl.Application.Positions.Services;

public class PositionsService(IUnitOfWork unitOfWork) : IPositionsService
{
    public async Task<IEnumerable<Position>> FindManyAsync(FindManyPositionsRequest request)
    {
        var positions = await unitOfWork.PositionsRepository.FindManyAsync(request);
        
        return positions;
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyPositionsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.PositionsRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Position> FindOneAsync(Guid id)
    {
        return await unitOfWork.PositionsRepository.FindOneAsync(new () { Id = id }) 
               ?? throw new NotFoundException(Errors.POSITION_NOT_FOUND);
    }

    public async Task<Position?> CreateAsync(CreatePositionsRequest request)
    {
        var position = new Position(request);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.CreateAsync(position);
        await unitOfWork.Commit(transaction);
        
        return position;
    }

    public async Task UpdateAsync(Guid id, UpdatePositionsRequest request)
    {
        var position = await FindOneAsync(id);
        position.Update(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Update(position);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var position = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Delete(position);
        await unitOfWork.Commit(transaction);
    }
}