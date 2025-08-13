using ITControl.Application.Interfaces;
using ITControl.Communication.Divisions.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class DivisionsView : IDivisionsView
{
    public CreateDivisionsResponse? Create(Division? division)
    {
        if (division == null) return null;

        return new CreateDivisionsResponse()
        {
            Id = division.Id.ToString(),
        };
    }

    public FindOneDivisionsResponse? FindOne(Division? division)
    {
        if (division == null) return null;

        return new FindOneDivisionsResponse()
        {
            Id = division.Id.ToString(),
            Name = division.Name,
            DepartmentId = division.DepartmentId.ToString(),
            UserId = division.UserId.ToString(),
            Department = division.Department != null ? new FindOneDivisionsDepartmentResponse()
            {
                Id = division.Department.Id.ToString(),
                Name = division.Department.Name,
            } : null,
            User = division.User != null ? new FindOneDivisionsUserResponse()
            {
                Id = division.User.Id.ToString(),
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
                Id = division.Id.ToString(),
                Name = division.Name,
                DepartmentId = division.DepartmentId.ToString(),
                UserId = division.UserId.ToString(),
            };
    }
}