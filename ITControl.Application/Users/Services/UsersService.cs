using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Users.Interfaces;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Services;

public class UsersService(IUnitOfWork unitOfWork) : IUsersService
{
    public async Task<User> FindOneAsync(
        Guid id, 
        bool? includePosition = null, 
        bool? includeRole = null,
        bool? includeUsersEquipments = null,
        bool? includeUsersSystems = null)
    {
        return await unitOfWork.UsersRepository
            .FindOneAsync(
                id, 
                true, 
                true, 
                true, 
                true) 
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
        await CheckConflicts(null, request.Name, request.Username, request.Email);
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistence(
            positionId: request.PositionId,
            roleId: request.RoleId,
            equipments: request.Equipments,
            systems: request.Systems);
        var user = new User(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: Crypt.HashPassword(request.Password),
            enrollment: request.Enrollment,
            positionId: request.PositionId,
            roleId: request.RoleId);
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

    public async Task UpdateAsync(Guid id, UpdateUsersRequest request)
    {
        await CheckConflicts(id, request.Name, request.Username, request.Email);
        await CheckExistence(
            positionId: request.PositionId,
            roleId: request.RoleId,
            equipments: request.Equipments,
            systems: request.Systems);
        var user = await FindOneAsync(id);
        user.Update(
            username: request.Username,
            email: request.Email,
            name: request.Name,
            password: request.Password != null ? Crypt.HashPassword(request.Password) : null,
            enrollment: request.Enrollment,
            positionId: request.PositionId,
            roleId: request.RoleId,
            active: request.Active);
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
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersEquipmentsRepository.CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository.CreateManyAsync(usersSystems);
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id, DeleteUsersRequest request)
    {
        var user = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        CheckUserLogged(user.Id, request.LoggedUserId);
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        unitOfWork.UsersRepository.SoftDelete(user);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckConflicts(
        Guid? id = null, 
        string? name = null, 
        string? username = null, 
        string? email = null)
    {
        var messages = new List<string>();
        
        if (name != null)
            await CheckNameConflict(id, name, messages);
        if (username != null)
            await CheckUsernameConflict(id, username, messages);
        if (email != null)
            await CheckEmailConflict(id, email, messages);
        
        if (messages.Count > 0)
            throw new ConflictException(string.Join(", ", messages));
    }

    private async Task CheckNameConflict(Guid? id, string name, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.UsersRepository.ExclusiveAsync((Guid)id, name) 
            : await unitOfWork.UsersRepository.ExistsAsync(name: name);

        if (exists)
        {
            messages.Add("Page with this name already exists");
        }
    }

    private async Task CheckUsernameConflict(Guid? id, string username, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.UsersRepository.ExclusiveAsync((Guid)id, username) 
            : await unitOfWork.UsersRepository.ExistsAsync(username: username);

        if (exists)
        {
            messages.Add("Page with this username already exists");
        }
    }

    private async Task CheckEmailConflict(Guid? id, string email, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.UsersRepository.ExclusiveAsync((Guid)id, email) 
            : await unitOfWork.UsersRepository.ExistsAsync(email: email);

        if (exists)
        {
            messages.Add("Page with this email already exists");
        }
    }

    private async Task CheckExistence(
        Guid? positionId, 
        Guid? roleId, 
        IEnumerable<CreateUsersEquipmentsRequest>? equipments,
        IEnumerable<CreateUsersSystemsRequest>? systems)
    {
        var messages = new List<string>();

        if (positionId != null) await CheckPositionExistence((Guid)positionId, messages);
        if (roleId != null) await CheckRoleExistence((Guid)roleId, messages);
        if (equipments != null)
        {
            foreach (var equipment in equipments)
            {
                await CheckEquipmentExistence(equipment.EquipmentId, messages);
            }
        }
        if (systems != null)
        {
            foreach (var system in systems)
            {
                await CheckSystemExistence(system.SystemId, messages);
            }
        }

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

    private async Task CheckEquipmentExistence(Guid equipmentId, List<string> messages)
    {
        var exists = await unitOfWork.EquipmentsRepository.ExistsAsync(id: equipmentId);
        if (!exists)
            messages.Add("Equipment not found");
    }

    private async Task CheckSystemExistence(Guid systemId, List<string> messages)
    {
        var exists = await unitOfWork.SystemsRepository.ExistsAsync(id: systemId);
        if (!exists)
            messages.Add("System not found");
    }

    private void CheckUserLogged(Guid userId, Guid loggedUserId)
    {
        if (loggedUserId == Guid.Empty)
            throw new BadRequestException("Logged user ID is required");
        if (userId == loggedUserId)
            throw new BadRequestException("You are not authorized to perform this action");
    }
}