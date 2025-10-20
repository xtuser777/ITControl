using ITControl.Application.Departments.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Departments.Entities;

namespace ITControl.Application.Departments.Interfaces;

public interface IDepartmentsService
{
    Task<Department> FindOneAsync(
        FindOneDepartmentsServiceParams @params);
    Task<IEnumerable<Department>> FindManyAsync(
        FindManyDepartmentsServiceParams @params);
    Task<PaginationResponse?> FindManyPagination(
        FindManyPaginationDepartmentsServiceParams @params);
    Task<Department?> CreateAsync(CreateDepartmentsServiceParams @params);
    Task UpdateAsync(UpdateDepartmentsServiceParams @params);
    Task DeleteAsync(DeleteDepartmentsServiceParams @params);
}