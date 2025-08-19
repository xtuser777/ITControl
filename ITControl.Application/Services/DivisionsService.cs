using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class DivisionsService(IUnitOfWork unitOfWork) : IDivisionsService
{
    public async Task<Division?> FindOneAsync(
        Guid id, bool? includeDepartment = null, bool? includeUser = null)
    {
        return await unitOfWork
            .DivisionsRepository
            .FindOneAsync(x => x.Id == id, includeDepartment, includeUser);
    }

    private async Task<Division> FindOneOrThrowAsync(
        Guid id, bool? includeDepartment = null, bool? includeUser = null)
    {
        return await FindOneAsync(id, includeDepartment, includeUser) 
            ?? throw new NotFoundException("divisão não encontrada");
    }
    
    public async Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DivisionsRepository.FindManyAsync(
            name: request.Name,
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            userId: Parser.ToGuidOptional(request.UserId),
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
            departmentId: Parser.ToGuidOptional(request.DepartmentId),
            userId: Parser.ToGuidOptional(request.UserId));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Division?> CreateAsync(CreateDivisionsRequest request)
    {
        await CheckExistence(
            Parser.ToGuid(request.UserId), 
            Parser.ToGuid(request.DepartmentId));
        var division = new Division(
            request.Name, 
            Parser.ToGuid(request.DepartmentId), 
            Parser.ToGuid(request.UserId));
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DivisionsRepository.CreateAsync(division);
        await unitOfWork.Commit(transaction);

        return division;
    }

    public async Task UpdateAsync(Guid id, UpdateDivisionsRequest request)
    {
        await CheckExistence(
            Parser.ToGuidOptional(request.UserId), 
            Parser.ToGuidOptional(request.DepartmentId));
        var division = await FindOneOrThrowAsync(id);
        division.Update(
            request.Name,
            Parser.ToGuidOptional(request.DepartmentId),
            Parser.ToGuidOptional(request.UserId));
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Update(division);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var division = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DivisionsRepository.Delete(division);
        await unitOfWork.Commit(transaction);
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
            messages.Add("the user does not exist");
        }
    }

    private async Task CheckDepartmentExistence(Guid departmentId, List<string> messages)
    {
        var department = await unitOfWork.DepartmentsRepository.ExistsAsync(id: departmentId);
        if (department == false)
        {
            messages.Add("the department does not exist");
        }
    }
}