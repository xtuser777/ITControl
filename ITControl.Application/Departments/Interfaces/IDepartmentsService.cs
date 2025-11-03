using ITControl.Application.Shared.Params;
using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Departments.Interfaces;

public interface IDepartmentsService
{
    Task<Department> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Department>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters);
    Task<Department?> CreateAsync(CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}