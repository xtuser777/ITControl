using ITControl.Application.Interfaces;
using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Roles.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Application.Roles.Services;

public class RolesService(IUnitOfWork unitOfWork) : IRolesService
{
    public async Task<Role> FindOneAsync(Guid id, bool? includeRolesPages = null)
    {
        return await unitOfWork
            .RolesRepository.FindOneAsync(id, includeRolesPages) 
               ?? throw new NotFoundException("Role not found");
    }

    public async Task<IEnumerable<Role>> FindManyAsync(FindManyRolesRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.RolesRepository.FindManyAsync(
            name: request.Name,
            active: Parser.ToBoolOptional(request.Active),
            orderByName: request.OrderByName,
            orderByActive: request.OrderByActive,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyRolesRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.RolesRepository.CountAsync(
            name: request.Name, 
            active: Parser.ToBoolOptional(request.Active));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Role?> CreateAsync(CreateRolesRequest request)
    {
        await CheckConflicts(name: request.Name);
        await CheckConnections((List<CreateRolesPagesRequest>)request.RolesPages);
        var role = new Role(name: request.Name, active: true);
        var rolesPages = from page in request.RolesPages
            select new RolePage(
                roleId: role.Id,
                pageId: page.PageId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.RolesRepository.CreateAsync(role);
        await unitOfWork.RolesPagesRepository.CreateManyAsync(rolesPages);
        await unitOfWork.Commit(transaction);
        
        return role;
    }

    public async Task UpdateAsync(Guid id, UpdateRolesRequest request)
    {
        await CheckConflicts(id, name: request.Name);
        await CheckConnections((List<CreateRolesPagesRequest>?)request.RolesPages);
        var role = await FindOneAsync(id);
        role.Update(name: request.Name, active: request.Active);
        var rolesPages = from page in request.RolesPages
            select new RolePage(
                roleId: role.Id,
                pageId: page.PageId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.RolesPagesRepository.DeleteManyByRoleAsync(role);
        await unitOfWork.RolesPagesRepository.CreateManyAsync(rolesPages);
        unitOfWork.RolesRepository.Update(role);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.RolesRepository.Delete(role);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckConflicts(Guid? id = null, string? name = null)
    {
        var messages = new List<string>();
        
        if (name != null)
            await CheckNameConflict(id, name, messages);
        
        if (messages.Count > 0)
            throw new ConflictException(string.Join(", ", messages));
    }

    private async Task CheckNameConflict(Guid? id, string name, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.RolesRepository.ExclusiveAsync((Guid)id, name) 
            : await unitOfWork.RolesRepository.ExistsAsync(name: name);

        if (exists)
        {
            messages.Add("Role with this name already exists");
        }
    }

    private async Task CheckConnections(List<CreateRolesPagesRequest>? rolesPages)
    {
        var messages = new List<string>();

        if (rolesPages == null || rolesPages.Count == 0) messages.Add("No roles pages found");
        else
        {
            foreach (var page in rolesPages)
            {
                await CheckPageExistence(page.PageId, messages);
            }
        }

        if (messages.Count > 0)
            throw new ExistenceException(string.Join(", ", messages));
    }

    private async Task CheckPageExistence(Guid pageId, List<string> messages)
    {
        var exists = await unitOfWork.PagesRepository.ExistsAsync(id: pageId);
        if (exists == false)
            messages.Add("Page not exists");
    }
}