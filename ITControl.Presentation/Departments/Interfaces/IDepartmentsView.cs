using ITControl.Domain.Departments.Entities;
using ITControl.Presentation.Departments.Responses;

namespace ITControl.Presentation.Departments.Interfaces;

public interface IDepartmentsView
{
    CreateDepartmentsResponse? Create(Department? department);
    FindOneDepartmentsResponse? FindOne(Department? department);
    IEnumerable<FindManyDepartmentsResponse> FindMany(IEnumerable<Department>? departments);
}