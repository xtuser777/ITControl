using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Departments.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Departments.Services;

public class DepartmentsService(IUnitOfWork unitOfWork) : IDepartmentsService
{
    public async Task<Department> FindOneAsync(FindOneDepartmentsServiceParams @params)
    {
        return await unitOfWork
                   .DepartmentsRepository
                   .FindOneAsync(@params)
               ?? throw new NotFoundException(Errors.DEPARTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        FindManyDepartmentsServiceParams @params)
    {
        var entities = await unitOfWork.DepartmentsRepository.FindManyAsync(
            @params.FindManyParams, 
            @params.OrderByParams, 
            @params.PaginationParams);
        
        return entities.Cast<Department>();
    }

    public async Task<PaginationResponse?> FindManyPagination(
        FindManyPaginationDepartmentsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.DepartmentsRepository.CountAsync(
            @params.CountParams);
        
        var pagination = Pagination.Build(@params.Page, @params.Size, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateDepartmentsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var department = new Department(@params.Params);
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(UpdateDepartmentsServiceParams @params)
    {
        var department = await FindOneAsync(@params);
        department.Update(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Update(department);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteDepartmentsServiceParams @params)
    {
        var department = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Delete(department);
        await unitOfWork.Commit(transaction);
    }
}