using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Departments.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department> FindOneAsync(Guid id)
    {
        return await unitOfWork
            .DepartmentsRepository
            .FindOneAsync(id, true)
               ?? throw new NotFoundException(Errors.DEPARTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DepartmentsRepository.FindManyAsync(
            alias: request.Alias,
            name: request.Name,
            userId: request.UserId,
            orderByAlias: request.OrderByAlias,
            orderByName: request.OrderByName,
            orderByUser: request.OrderByUser,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPagination(FindManyDepartmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.DepartmentsRepository.CountAsync(
            alias: request.Alias,
            name: request.Name,
            userId: request.UserId);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateDepartmentsRequest request)
    {
        await CheckConflicts(name: request.Name, alias: request.Alias);
        await CheckExistence(request.UserId);
        var department = new Department(
            alias: request.Alias,
            name: request.Name,
            userId: request.UserId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(Guid id, UpdateDepartmentsRequest request)
    {
        await CheckConflicts(id, request.Name, request.Alias);
        await CheckExistence(request.UserId);
        var department = await FindOneAsync(id);
        department.Update(
            alias: request.Alias,
            name: request.Name,
            userId: request.UserId);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Update(department);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Delete(department);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckConflicts(Guid? id = null, string? name = null, string? alias = null)
    {
        var messages = new List<string>();
        
        if (name != null)
            await CheckNameConflict(id, name, messages);
        if (alias != null)
            await CheckAliasConflict(id, alias, messages);
        
        if (messages.Count > 0)
            throw new ConflictException(string.Join(", ", messages));
    }

    private async Task CheckNameConflict(Guid? id, string name, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.DepartmentsRepository.ExclusiveAsync((Guid)id, name) 
            : await unitOfWork.DepartmentsRepository.ExistsAsync(name: name);

        if (exists)
        {
            messages.Add(Errors.DEPARTMENT_NAME_EXISTS);
        }
    }

    private async Task CheckAliasConflict(Guid? id, string alias, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.DepartmentsRepository.ExclusiveAsync((Guid)id, alias) 
            : await unitOfWork.DepartmentsRepository.ExistsAsync(alias: alias);

        if (exists)
        {
            messages.Add(Errors.DEPARTMENT_ALIAS_EXISTS);
        }
    }

    private async Task CheckExistence(Guid? userId)
    {
        var messages = new List<string>();
        if (userId.HasValue)
        {
            await CheckUserExistence(userId.Value, messages);
        }
        if (messages.Count > 0)
        {
            throw new NotFoundException(string.Join(", ", messages));
        }
    }

    private async Task CheckUserExistence(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(id: userId);
        if (user == false)
        {
            messages.Add(Errors.USER_NOT_FOUND);
        }
    }
}