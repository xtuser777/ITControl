using ITControl.Domain.Departments.Entities;
using ITControl.Presentation.Departments.Interfaces;
using ITControl.Presentation.Departments.Responses;

namespace ITControl.Presentation.Departments.Views;

public class DepartmentsView : IDepartmentsView
{
    public CreateDepartmentsResponse? Create(Department? department)
    {
        if (department == null) return null;

        return new CreateDepartmentsResponse
        {
            Id = department.Id,
        };
    }

    public FindOneDepartmentsResponse? FindOne(Department? department)
    {
        if (department == null) return null;

        return new FindOneDepartmentsResponse
        {
            Id = department.Id,
            Alias = department.Alias,
            Name = department.Name,
        };
    }

    public IEnumerable<FindManyDepartmentsResponse> FindMany(
        IEnumerable<Department>? departments)
    {
        if (departments == null) return [];

        return 
            from department in departments 
            select new FindManyDepartmentsResponse
            {
                Id = department.Id,
                Alias = department.Alias,
                Name = department.Name,
            };
    }
}