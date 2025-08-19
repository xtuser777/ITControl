using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department?> FindOneAsync(Guid id)
    {
        return await unitOfWork
            .DepartmentsRepository
            .FindOneAsync(x => x.Id == id, true);
    }

    public async Task<Department> FindOneOrThrowAsync(Guid id)
    {
        return await FindOneAsync(id) 
            ?? throw new NotFoundException("department not found");
    }

    public async Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DepartmentsRepository.FindManyAsync(
            alias: request.Alias,
            name: request.Name,
            userId: Parser.ToGuidOptional(request.UserId),
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
            userId: Parser.ToGuidOptional(request.UserId));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateDepartmentsRequest request)
    {
        await CheckExistence(Parser.ToGuid(request.UserId));
        var department = new Department(
            alias: request.Alias,
            name: request.Name,
            userId: Parser.ToGuid(request.UserId));
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(Guid id, UpdateDepartmentsRequest request)
    {
        await CheckExistence(Parser.ToGuidOptional(request.UserId));
        var department = await FindOneOrThrowAsync(id);
        department.Update(
            alias: request.Alias,
            name: request.Name,
            userId: Parser.ToGuidOptional(request.UserId));
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Update(department);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Delete(department);
        await unitOfWork.Commit(transaction);
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
            messages.Add("the user does not exist");
        }
    }
}