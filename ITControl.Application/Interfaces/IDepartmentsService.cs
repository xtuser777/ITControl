using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IDepartmentsService
{
    Task<Department> FindOneAsync(Guid id);
    Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManyDepartmentsRequest request);
    Task<Department?> CreateAsync(CreateDepartmentsRequest request);
    Task UpdateAsync(Guid id, UpdateDepartmentsRequest request);
    Task DeleteAsync(Guid id);
}