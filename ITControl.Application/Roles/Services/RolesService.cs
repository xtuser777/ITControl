using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Props;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using System.Runtime.CompilerServices;

namespace ITControl.Application.Roles.Services;

public class RolesService(IUnitOfWork unitOfWork) : IRolesService
{
    public async Task<Role> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .RolesRepository.FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.ROLE_NOT_FOUND);
    }

    public async Task<IEnumerable<Role>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.RolesRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginatedAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.RolesRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Role?> CreateAsync(
        CreateServiceParams parameters)
    {
        var role = new Role((RoleProps)parameters.Props);
        var rolesPages = 
            ((RoleProps)parameters.Props).RolesPages!.ToList();
        rolesPages.ForEach(rp => rp.RoleId = role.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.RolesRepository.CreateAsync(role);
        await unitOfWork.RolesPagesRepository
            .CreateManyAsync(rolesPages);
        await unitOfWork.Commit(transaction);
        
        return role;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var role = await FindOneAsync(parameters);
        role.Update((RoleProps)parameters.Props);
        var rolesPages = 
            ((RoleProps)parameters.Props).RolesPages!.ToList();
        rolesPages.ForEach(rp => rp.RoleId = role.Id);
        await unitOfWork.RolesPagesRepository.DeleteManyByRoleAsync(role);
        await unitOfWork.RolesPagesRepository.CreateManyAsync(rolesPages);
        unitOfWork.RolesRepository.Update(role);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var role = await FindOneAsync(parameters);
        await CheckDependenciesAsync(role.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.RolesPagesRepository.DeleteManyByRoleAsync(role);
        unitOfWork.RolesRepository.Delete(role);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid roleId)
    {
        await CheckUserDependenciesAsync(roleId);
    }

    private async Task CheckUserDependenciesAsync(Guid roleId)
    {
        var users = await unitOfWork.UsersRepository
            .CountAsync(new Domain.Users.Props.UserProps
            {
                RoleId = roleId
            });
        if (users > 0)
        {
            throw new BadRequestException($"O perfil possui vínculo com {users} usuários");
        }
    }
}