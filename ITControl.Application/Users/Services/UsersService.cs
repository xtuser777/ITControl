using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Users.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Props;

namespace ITControl.Application.Users.Services;

public class UsersService(IUnitOfWork unitOfWork) : IUsersService
{
    public async Task<User> FindOneAsync(
            FindOneServiceParams parameters)
    {
        return await unitOfWork.UsersRepository
                   .FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
    }

    public async Task<IEnumerable<User>> FindManyAsync(
            FindManyServiceParams parameters)
    {
        return await unitOfWork.UsersRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
            FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.UsersRepository
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<User?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = new User((UserProps)parameters.Props);
        var usersEquipments = 
            ((UserProps)parameters.Props).UsersEquipments!.ToList();
        usersEquipments.ForEach(ue => ue.UserId = user.Id);
        var usersSystems = 
            ((UserProps)parameters.Props).UsersSystems!.ToList();
        usersSystems.ForEach(ue => ue.UserId = user.Id);
        await unitOfWork.UsersRepository.CreateAsync(user);
        await unitOfWork.UsersEquipmentsRepository
            .CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository
            .CreateManyAsync(usersSystems);
        await unitOfWork.Commit(transaction);

        return user;
    }

    [Obsolete("Obsolete")]
    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(parameters);
        user.Update((UserProps)parameters.Props);
        var usersEquipments = 
            ((UserProps)parameters.Props).UsersEquipments!.ToList();
        usersEquipments.ForEach(ue => ue.UserId = user.Id);
        var usersSystems = 
            ((UserProps)parameters.Props).UsersSystems!.ToList();
        usersSystems.ForEach(ue => ue.UserId = user.Id);
        await unitOfWork.UsersEquipmentsRepository
            .DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository
            .DeleteManyByUserAsync(user);
        await unitOfWork.UsersEquipmentsRepository
            .CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository
            .CreateManyAsync(usersSystems);
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(parameters);
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        unitOfWork.UsersRepository.SoftDelete(user);
        await unitOfWork.Commit(transaction);
    }
}