using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department?> FindOneAsync(Guid id)
    {
        return await unitOfWork.DepartmentsRepository.FindOneAsync(id, true);
    }

    public async Task<Department> FindOneOrThrowAsync(Guid id)
    {
        var department = await FindOneAsync(id);
        if (department == null)
            throw new NotFoundException("department not found");
        
        return department;
    }

    public async Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.DepartmentsRepository.FindManyAsync(
            alias: request.Alias,
            name: request.Name,
            userId: Guid.Parse((ReadOnlySpan<char>)request.UserId),
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
            userId: Guid.Parse((ReadOnlySpan<char>)request.UserId));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateDepartmentsRequest request)
    {
        var department = Department.Create(
            alias: request.Alias,
            name: request.Name,
            userId: Guid.Parse((ReadOnlySpan<char>)request.UserId));
        await unitOfWork.DepartmentsRepository.CreateAsync(department);

        return department;
    }

    public async Task UpdateAsync(Guid id, UpdateDepartmentsRequest request)
    {
        var department = await FindOneOrThrowAsync(id);
        department.Update(
            alias: request.Alias,
            name: request.Name,
            userId: Guid.Parse((ReadOnlySpan<char>)request.UserId));
        await unitOfWork.DepartmentsRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await FindOneOrThrowAsync(id);
        await unitOfWork.DepartmentsRepository.DeleteAsync(department);
    }
}