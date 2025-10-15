using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Roles.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Roles.Services;

public class RolesService(IUnitOfWork unitOfWork) : IRolesService
{
    public async Task<Role> FindOneAsync(FindOneRolesRequest request)
    {
        return await unitOfWork
            .RolesRepository.FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.ROLE_NOT_FOUND);
    }

    public async Task<IEnumerable<Role>> FindManyAsync(
        FindManyRolesRequest request, OrderByRolesRequest orderByRolesRequest)
    {
        return await unitOfWork.RolesRepository.FindManyAsync(
            request, orderByRolesRequest, request);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyRolesRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.RolesRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Role?> CreateAsync(CreateRolesRequest request)
    {
        var role = new Role(request);
        var rolesPages = from page in request.RolesPages
            select new RolePage(roleId: role.Id, pageId: page.PageId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.RolesRepository.CreateAsync(role);
        await unitOfWork.RolesPagesRepository.CreateManyAsync(rolesPages);
        await unitOfWork.Commit(transaction);
        
        return role;
    }

    public async Task UpdateAsync(Guid id, UpdateRolesRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var role = await FindOneAsync(new () { Id = id });
        role.Update(request);
        var rolesPages = from page in request.RolesPages
            select new RolePage(
                roleId: role.Id,
                pageId: page.PageId);
        await unitOfWork.RolesPagesRepository.DeleteManyByRoleAsync(role);
        await unitOfWork.RolesPagesRepository.CreateManyAsync(rolesPages);
        unitOfWork.RolesRepository.Update(role);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.RolesRepository.Delete(role);
        await unitOfWork.Commit(transaction);
    }
}