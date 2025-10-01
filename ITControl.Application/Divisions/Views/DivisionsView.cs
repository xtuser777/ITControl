using ITControl.Application.Divisions.Interfaces;
using ITControl.Communication.Divisions.Responses;
using ITControl.Domain.Divisions.Entities;

namespace ITControl.Application.Divisions.Views;

public class DivisionsView : IDivisionsView
{
    public CreateDivisionsResponse? Create(Division? division)
    {
        if (division == null) return null;

        return new CreateDivisionsResponse()
        {
            Id = division.Id,
        };
    }

    public FindOneDivisionsResponse? FindOne(Division? division)
    {
        if (division == null) return null;

        return new FindOneDivisionsResponse()
        {
            Id = division.Id,
            Name = division.Name,
            DepartmentId = division.DepartmentId,
            Department = division.Department != null ? new FindOneDivisionsDepartmentResponse()
            {
                Id = division.Department.Id,
                Alias = division.Department.Alias,
                Name = division.Department.Name,
            } : null,
        };
    }

    public IEnumerable<FindManyDivisionsResponse> FindMany(IEnumerable<Division>? divisions)
    {
        if (divisions == null) return [];

        return from division in divisions
            select new FindManyDivisionsResponse()
            {
                Id = division.Id,
                Name = division.Name,
                DepartmentId = division.DepartmentId,
            };
    }
}