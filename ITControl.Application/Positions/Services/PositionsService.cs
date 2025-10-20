using ITControl.Application.Positions.Interfaces;
using ITControl.Application.Positions.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Positions.Services;

public class PositionsService(IUnitOfWork unitOfWork) : IPositionsService
{
    public async Task<Position> FindOneAsync(FindOnePositionsServiceParams @params)
    {
        return await unitOfWork.PositionsRepository.FindOneAsync(@params) 
            ?? throw new NotFoundException(Errors.POSITION_NOT_FOUND);
    }

    public async Task<IEnumerable<Position>> FindManyAsync(
        FindManyPositionsServiceParams @params)
    {
        return await unitOfWork.PositionsRepository.FindManyAsync(
            @params.FindManyParams, 
            @params.OrderByParams, 
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationPositionsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) 
            return null;
        
        var count = await unitOfWork.PositionsRepository
            .CountAsync(@params.CountParams);
        
        var pagination = Pagination.Build(@params.Page, @params.Size, count);
        
        return pagination;
    }

    public async Task<Position?> CreateAsync(CreatePositionsServiceParams @params)
    {
        var position = new Position(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.CreateAsync(position);
        await unitOfWork.Commit(transaction);
        
        return position;
    }

    public async Task UpdateAsync(UpdatePositionsServiceParams @params)
    {
        var position = await FindOneAsync(@params);
        position.Update(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Update(position);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeletePositionsServiceParams @params)
    {
        var position = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Delete(position);
        await unitOfWork.Commit(transaction);
    }
}