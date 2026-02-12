using ITControl.Application.Departments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Props;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.SuppliesMovements.Props;

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
        return await unitOfWork.DepartmentsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.DepartmentsRepository.CountAsync(
            parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        
        return pagination;
    }

    public async Task<Department?> CreateAsync(CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var department = new Department((DepartmentProps)parameters.Props);
        await unitOfWork.DepartmentsRepository.CreateAsync(department);
        await unitOfWork.Commit(transaction);

        return department;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var department = await FindOneAsync(parameters);
        department.Update((DepartmentProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Update(department);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var department = await FindOneAsync(parameters);
        await CheckDependenciesAsync(department.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DepartmentsRepository.Delete(department);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid departmentId)
    {
        await CheckDivisionDependenciesAsync(departmentId);
        await CheckSupplyMovemntDependenciesAsync(departmentId);
        await CheckUserDependenciesAsync(departmentId);
    }

    private async Task CheckDivisionDependenciesAsync(Guid departmentId)
    {
        var divisions = await unitOfWork
            .DivisionsRepository
            .CountAsync(new CountDivisionsParams
            { DepartmentId = departmentId });
        if (divisions > 0)
        {
            throw new BadRequestException(
                $"A secreataria possui vínculo com {divisions} divisões");
        }
    }

    private async Task CheckSupplyMovemntDependenciesAsync(Guid departmentId)
    {
        var suplementMovements = await unitOfWork.SuppliesMovementsRepository
            .CountAsync(new SupplyMovementProps
            {
                DepartmentId = departmentId
            });
        if (suplementMovements > 0)
        {
            throw new BadRequestException(
                $"A secretaria possui vínculo com {suplementMovements} movimentos de suplementos");
        }
    }

    private async Task CheckUserDependenciesAsync(Guid departmentId)
    {
        var users = await unitOfWork.UsersRepository
            .CountAsync(new Domain.Users.Props.UserProps
            {
                DepartmentId = departmentId
            });
        if (users > 0)
        {
            throw new BadRequestException(
                $"A secretaria possui vínculo com {users} usuários");
        }
    }
}