using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Positions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class PositionsService(IUnitOfWork unitOfWork) : IPositionsService
{
    public async Task<IEnumerable<Position>> FindMany(FindManyPositionsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        var positions = await unitOfWork.PositionsRepository.FindManyAsync(
            request.Description,
            request.OrderByDescription,
            page,
            size
        );
        
        return positions;
    }

    public async Task<PaginationResponse?> FindManyPagination(FindManyPositionsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.PositionsRepository.CountAsync(description: request.Description);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Position?> FindOne(Guid id)
    {
        var position = await unitOfWork.PositionsRepository.FindOneAsync(id);
        
        return position;
    }

    private async Task<Position> FindOneOrThrow(Guid id)
    {
        var position = await FindOne(id);
        if (position == null) 
            throw new NotFoundException("Position not found");
        
        return position;
    }

    public async Task<Position?> Create(CreatePositionsRequest request)
    {
        await CheckConflicts(description: request.Description);
        var position = Position.Create(request.Description);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.CreateAsync(position);
        await unitOfWork.Commit(transaction);
        
        return position;
    }

    public async Task Update(Guid id, UpdatePositionsRequest request)
    {
        await CheckConflicts(id, description: request.Description);
        var position = await FindOneOrThrow(id);
        position.Update(request.Description);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.UpdateAsync(position);
        await unitOfWork.Commit(transaction);
    }

    public async Task Delete(Guid id)
    {
        var position = await FindOneOrThrow(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.DeleteAsync(position);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckConflicts(Guid? id = null, string? description = null)
    {
        var messages = new List<string>();
        
        if (description != null)
            await CheckDescriptionConflict(id, description, messages);
        
        if (messages.Count > 0)
            throw new ConflictException(string.Join(", ", messages));
    }

    private async Task CheckDescriptionConflict(Guid? id, string description, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.PositionsRepository.ExclusiveAsync((Guid)id, description) 
            : await unitOfWork.PositionsRepository.ExistAsync(description: description);

        if (exists)
        {
            messages.Add("Position with this description already exists");
        }
    }
}