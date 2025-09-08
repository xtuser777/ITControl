using ITControl.Application.Divisions.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Divisions.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division> FindOneAsync(
        Guid id, bool? includeDepartment = null, bool? includeUser = null)
    {
        return await unitOfWork
            .DivisionsRepository
            .FindOneAsync(id, includeDepartment, includeUser)
               ?? throw new NotFoundException(Errors.DIVISION_NOT_FOUND);
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DivisionsRepository.FindManyAsync(
            name: request.Name,
            departmentId: request.DepartmentId,
            userId: request.UserId,
            orderByName: request.OrderByName,
            orderByDepartment: request.OrderByDepartment,
            orderByUser: request.OrderByUser,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.DivisionsRepository.CountAsync(
            name: request.Name,
            departmentId: request.DepartmentId,
            userId: request.UserId);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(CreateDivisionsRequest request)
    {
        await CheckConflicts(name: request.Name);
        await CheckExistence(
            request.UserId, 
            request.DepartmentId);
        var division = new Division(
            request.Name, 
            request.DepartmentId, 
            request.UserId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(Guid id, UpdateDivisionsRequest request)
    {
        await CheckConflicts(id, request.Name);
        await CheckExistence(
            request.UserId, 
            request.DepartmentId);
        var division = await FindOneAsync(id);
        division.Update(
            request.Name,
            request.DepartmentId,
            request.UserId);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var division = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
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
            ? await unitOfWork.DivisionsRepository.ExclusiveAsync((Guid)id, name) 
            : await unitOfWork.DivisionsRepository.ExistsAsync(name: name);

        if (exists)
        {
            messages.Add(Errors.DIVISION_NAME_EXISTS);
        }
    }

    private async Task CheckExistence(Guid? userId, Guid? departmentId)
    {
        var messages = new List<string>();
        if (userId.HasValue)
        {
            await CheckUserExistence(userId.Value, messages);
        }
        if (departmentId.HasValue)
        {
            await CheckDepartmentExistence(departmentId.Value, messages);
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

    private async Task CheckDepartmentExistence(Guid departmentId, List<string> messages)
    {
        var department = await unitOfWork.DepartmentsRepository.ExistsAsync(id: departmentId);
        if (department == false)
        {
            messages.Add(Errors.DEPARTMENT_NOT_FOUND);
        }
    }
}