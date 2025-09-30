using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Params;

namespace ITControl.Application.Departments.Interfaces;

public interface IDepartmentsService
{
    Task<Department> FindOneAsync(Guid id);
    Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRepositoryParams @params);
    Task<PaginationResponse?> FindManyPagination(FindManyDepartmentsRepositoryParams @params);
    Task<Department?> CreateAsync(Department department);
    Task UpdateAsync(Guid id, UpdateDepartmentParams @params);
    Task DeleteAsync(Guid id);
}