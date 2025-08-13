using ITControl.Communication.Departments.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IDepartmentsView
{
    CreateDepartmentsResponse? Create(Department? department);
    FindOneDepartmentsResponse? FindOne(Department? department);
    IEnumerable<FindManyDepartmentsResponse> FindMany(IEnumerable<Department>? departments);
}