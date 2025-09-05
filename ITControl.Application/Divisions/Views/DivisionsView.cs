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
            UserId = division.UserId,
            Department = division.Department != null ? new FindOneDivisionsDepartmentResponse()
            {
                Id = division.Department.Id,
                Name = division.Department.Name,
            } : null,
            User = division.User != null ? new FindOneDivisionsUserResponse()
            {
                Id = division.User.Id,
                Name = division.User.Name,
            } : null
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
                UserId = division.UserId,
            };
    }
}