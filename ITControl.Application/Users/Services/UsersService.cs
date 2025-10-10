using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Users.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Services;

public class UsersService(IUnitOfWork unitOfWork) : IUsersService
{
    public async Task<User> FindOneAsync(FindOneUsersRequest request)
    {
        return await unitOfWork.UsersRepository.FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyUsersRequest request)
    {
        return await unitOfWork.UsersRepository.FindManyAsync(request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.UsersRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    [Obsolete("Obsolete")]
    public async Task<User?> CreateAsync(CreateUsersRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = new User(request);
        var usersEquipments = from equipment in request.Equipments
            select
                new UserEquipment(
                    user.Id, 
                    equipment.EquipmentId, 
                    equipment.StartedAt,
                    equipment.EndedAt);
        var usersSystems = from system in request.Systems
            select
                new UserSystem(user.Id, system.SystemId);
        await unitOfWork.UsersRepository.CreateAsync(user);
        await unitOfWork.UsersEquipmentsRepository.CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository.CreateManyAsync(usersSystems);
        await unitOfWork.Commit(transaction);

        return user;
    }

    [Obsolete("Obsolete")]
    public async Task UpdateAsync(Guid id, UpdateUsersRequest request)
    {
        
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(new () { Id = id });
        user.Update(request);
        var usersEquipments = from equipment in request.Equipments
            select
                new UserEquipment(
                    user.Id, 
                    equipment.EquipmentId, 
                    equipment.StartedAt,
                    equipment.EndedAt);
        var usersSystems = from system in request.Systems
            select
                new UserSystem(user.Id, system.SystemId);
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersEquipmentsRepository.CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository.CreateManyAsync(usersSystems);
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(new() { Id = id });
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        unitOfWork.UsersRepository.SoftDelete(user);
        await unitOfWork.Commit(transaction);
    }
}