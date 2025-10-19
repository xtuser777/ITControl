using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;

namespace ITControl.Application.Departments.Interfaces;

public interface IDepartmentsService
{
    Task<Department> FindOneAsync(FindOneDepartmentsRequest request);
    Task<IEnumerable<Department>> FindManyAsync(
        FindManyDepartmentsRequest request,
        OrderByDepartmentsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPagination(FindManyDepartmentsRequest request);
    Task<Department?> CreateAsync(CreateDepartmentsRequest request);
    Task UpdateAsync(Guid id, UpdateDepartmentsRequest request);
    Task DeleteAsync(Guid id);
}