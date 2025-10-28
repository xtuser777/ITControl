using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Departments.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
                   .DepartmentsRepository
                   .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.DEPARTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        var entities = await unitOfWork.DepartmentsRepository
            .FindManyAsync(parameters);
        
        return entities.Cast<Department>();
    }

    public async Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.DepartmentsRepository.CountAsync(
            parameters.CountParams);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var department = new Department((DepartmentParams)parameters.Params);
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var department = await FindOneAsync(parameters);
        department.Update((UpdateDepartmentParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Update(department);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var department = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Delete(department);
        await unitOfWork.Commit(transaction);
    }
}