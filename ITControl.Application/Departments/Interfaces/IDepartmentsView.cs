using ITControl.Communication.Departments.Responses;
using ITControl.Domain.Departments.Entities;

namespace ITControl.Application.Departments.Interfaces;

public interface IDepartmentsView
{
    CreateDepartmentsResponse? Create(Department? department);
    FindOneDepartmentsResponse? FindOne(Department? department);
    IEnumerable<FindManyDepartmentsResponse> FindMany(IEnumerable<Department>? departments);
}