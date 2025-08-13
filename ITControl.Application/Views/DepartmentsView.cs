using ITControl.Application.Interfaces;
using ITControl.Communication.Departments.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class DepartmentsView : IDepartmentsView
{
    public CreateDepartmentsResponse? Create(Department? department)
    {
        if (department == null) return null;

        return new CreateDepartmentsResponse()
        {
            Id = department.Id.ToString(),
        };
    }

    public FindOneDepartmentsResponse? FindOne(Department? department)
    {
        if (department == null) return null;

        return new FindOneDepartmentsResponse()
        {
            Id = department.Id.ToString(),
            Alias = department.Alias,
            Name = department.Name,
            UserId = department.UserId.ToString(),
            User = department.User != null ? new FindOneDepartmentsUserResponse()
            {
                Id = department.User.Id.ToString(),
                Name = department.User.Name,
            } : null
        };
    }

    public IEnumerable<FindManyDepartmentsResponse> FindMany(IEnumerable<Department>? departments)
    {
        if (departments == null) return [];

        return from department in departments select new FindManyDepartmentsResponse()
        {
            Id = department.Id.ToString(),
            Alias = department.Alias,
            Name = department.Name,
            UserId = department.UserId.ToString(),
        };
    }
}