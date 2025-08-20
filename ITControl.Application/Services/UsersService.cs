using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class UsersService(IUnitOfWork unitOfWork) : IUsersService
{
    public async Task<User?> FindOneAsync(
        Guid id, 
        bool? includePosition, 
        bool? includeRole,
        bool? includeUsersEquipments,
        bool? includeUsersSystems)
    {
        return await unitOfWork.UsersRepository
            .FindOneAsync(
                x => x.Id == id, 
                true, 
                true, 
                true, 
                true);
    }

    private async Task<User> FindOneOrThrowAsync(Guid id)
    {
        return await FindOneAsync(id, null, null, null, null) 
            ?? throw new NotFoundException("Usuário não encontrado");
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyUsersRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.UsersRepository.FindManyAsync(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            active: Parser.ToBoolOptional(request.Active),
            orderByUsername: request.OrderByUsername,
            orderByName: request.OrderByName,
            orderByEmail: request.OrderByEmail,
            orderByActive: request.OrderByActive,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyUsersRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.UsersRepository.CountAsync(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            active: Parser.ToBoolOptional(request.Active));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<User?> CreateAsync(CreateUsersRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistence(
            positionId: Parser.ToGuid(request.PositionId),
            roleId: Parser.ToGuid(request.RoleId));
        var user = new User(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: Crypt.HashPassword(request.Password),
            enrollment: request.Enrollment,
            positionId: Parser.ToGuid(request.PositionId),
            roleId: Parser.ToGuid(request.RoleId));
        var usersEquipments = from equipment in request.Equipments
            select
                new UserEquipment(
                    user.Id, 
                    Parser.ToGuid(equipment.EquipmentId), 
                    Parser.ToDateOnly(equipment.StartedAt),
                    Parser.ToDateOnlyOptional(equipment.EndedAt));
        var usersSystems = from system in request.Systems
            select
                new UserSystem(user.Id, Parser.ToGuid(system.SystemId));
        await unitOfWork.UsersRepository.CreateAsync(user);
        await unitOfWork.UsersEquipmentsRepository.CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository.CreateManyAsync(usersSystems);
        await unitOfWork.Commit(transaction);

        return user;
    }

    public async Task UpdateAsync(Guid id, UpdateUsersRequest request)
    {
        await CheckExistence(
            positionId: Parser.ToGuidOptional(request.PositionId),
            roleId: Parser.ToGuidOptional(request.RoleId));
        var user = await FindOneOrThrowAsync(id);
        user.Update(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: request.Password != null ? Crypt.HashPassword(request.Password) : null,
            enrollment: request.Enrollment,
            positionId: Parser.ToGuidOptional(request.PositionId),
            roleId: Parser.ToGuidOptional(request.RoleId),
            active: request.Active);
        var usersEquipments = from equipment in request.Equipments
            select
                new UserEquipment(
                    user.Id, 
                    Parser.ToGuid(equipment.EquipmentId), 
                    Parser.ToDateOnly(equipment.StartedAt),
                    Parser.ToDateOnlyOptional(equipment.EndedAt));
        var usersSystems = from system in request.Systems
            select
                new UserSystem(user.Id, Parser.ToGuid(system.SystemId));
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersEquipmentsRepository.CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository.CreateManyAsync(usersSystems);
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        unitOfWork.UsersRepository.Delete(user);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistence(Guid? positionId, Guid? roleId)
    {
        var messages = new List<string>();

        if (positionId != null) await CheckPositionExistence((Guid)positionId, messages);
        if (roleId != null) await CheckRoleExistence((Guid)roleId, messages);

        if (messages.Count > 0) throw new NotFoundException(string.Join(",", messages));
    }

    private async Task CheckPositionExistence(Guid positionId, List<string> messages)
    {
        var exists = await unitOfWork.PositionsRepository.ExistsAsync(id: positionId);
        if (!exists)
            messages.Add("Position not found");
    }

    private async Task CheckRoleExistence(Guid roleId, List<string> messages)
    {
        var exists = await unitOfWork.RolesRepository.ExistsAsync(id: roleId);
        if (!exists)
            messages.Add("Role not found");
    }
}