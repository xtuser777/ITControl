using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Params;

namespace ITControl.Domain.Departments.Interfaces;

public interface IDepartmentsRepository
{
    Task<Department?> FindOneAsync(FindOneDepartmentsRepositoryParams @params);
    Task<IEnumerable<Department>> FindManyAsync(FindManyDepartmentsRepositoryParams @params);
    Task CreateAsync(Department department);
    void Update(Department department);
    void Delete(Department department);
    Task<int> CountAsync(CountDepartmentsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsDepartmentsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveDepartmentsRepositoryParams @params);
}