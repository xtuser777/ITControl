using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Exceptions;

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
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Role?> CreateAsync(
        CreateServiceParams parameters)
    {
        var role = new Role((RoleParams)parameters.Params);
        var rolesPages = 
            ((RoleParams)parameters.Params).Pages.ToList();
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
        role.Update((UpdateRoleParams)parameters.Params);
        var rolesPages = 
            ((UpdateRoleParams)parameters.Params).Pages.ToList();
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
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.RolesRepository.Delete(role);
        await unitOfWork.Commit(transaction);
    }
}