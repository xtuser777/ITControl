using ITControl.Application.Departments.Interfaces;
using ITControl.Communication.Departments.Responses;
using ITControl.Domain.Departments.Entities;

namespace ITControl.Application.Departments.Views;

public class DepartmentsView : IDepartmentsView
{
    public CreateDepartmentsResponse? Create(Department? department)
    {
        if (department == null) return null;

        return new CreateDepartmentsResponse()
        {
            Id = department.Id,
        };
    }

    public FindOneDepartmentsResponse? FindOne(Department? department)
    {
        if (department == null) return null;

        return new FindOneDepartmentsResponse()
        {
            Id = department.Id,
            Alias = department.Alias,
            Name = department.Name,
            UserId = department.UserId,
            User = department.User != null ? new FindOneDepartmentsUserResponse()
            {
                Id = department.User.Id,
                Name = department.User.Name,
            } : null
        };
    }

    public IEnumerable<FindManyDepartmentsResponse> FindMany(IEnumerable<Department>? departments)
    {
        if (departments == null) return [];

        return from department in departments select new FindManyDepartmentsResponse()
        {
            Id = department.Id,
            Alias = department.Alias,
            Name = department.Name,
            UserId = department.UserId,
        };
    }
}