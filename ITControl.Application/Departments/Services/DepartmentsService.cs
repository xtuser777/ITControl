using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Departments.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department> FindOneAsync(Guid id)
    {
        return await unitOfWork
            .DepartmentsRepository
            .FindOneAsync(new () { Id = id })
               ?? throw new NotFoundException(Errors.DEPARTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRepositoryParams @params)
    {
        return await unitOfWork.DepartmentsRepository.FindManyAsync(@params);
    }

    public async Task<PaginationResponse?> FindManyPagination(FindManyDepartmentsRepositoryParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.DepartmentsRepository.CountAsync(@params);
        
        var pagination = Pagination.Build(@params.Page?.ToString() ?? "", @params.Size?.ToString() ?? "", count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(Department department)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(Guid id, UpdateDepartmentParams @params)
    {
        var department = await FindOneAsync(id);
        department.Update(@params);
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
}