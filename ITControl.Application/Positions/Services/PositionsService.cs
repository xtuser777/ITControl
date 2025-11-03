using ITControl.Application.Positions.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Props;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Positions.Services;

public class PositionsService(IUnitOfWork unitOfWork) : IPositionsService
{
    public async Task<Position> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.PositionsRepository
                   .FindOneAsync(parameters) 
            ?? throw new NotFoundException(Errors.POSITION_NOT_FOUND);
    }

    public async Task<IEnumerable<Position>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.PositionsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.PositionsRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Position?> CreateAsync(
        CreateServiceParams parameters)
    {
        var position = new Position((PositionProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.CreateAsync(position);
        await unitOfWork.Commit(transaction);
        
        return position;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var position = await FindOneAsync(parameters);
        position.Update((PositionProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Update(position);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var position = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Delete(position);
        await unitOfWork.Commit(transaction);
    }
}