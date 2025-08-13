using ITControl.Application.Interfaces;
using ITControl.Communication.Locations.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class LocationsView : ILocationsView
{
    public CreateLocationsResponse? Create(Location? location)
    {
        if (location == null) return null;

        return new CreateLocationsResponse()
        {
            Id = location.Id.ToString(),
        };
    }

    public FindOneLocationsResponse? FindOne(Location? location)
    {
        if (location == null) return null;

        return new FindOneLocationsResponse()
        {
            Id = location.Id.ToString(),
            Description = location.Description,
            UnitId = location.UnitId.ToString(),
            UserId = location.UserId.ToString(),
            DepartmentId = location.DepartmentId.ToString(),
            DivisionId = location.DivisionId.ToString(),
            Department = location.Department != null
                ? new FindOneLocationsDepartmentResponse()
                {
                    Id = location.DepartmentId.ToString(),
                    Alias = location.Department.Alias,
                    Name = location.Department.Name,
                }
                : null,
            Division = location.Division != null
                ? new FindOneLocationsDivisionResponse()
                {
                    Id = location.Division.Id.ToString(),
                    Name = location.Division.Name,
                }
                : null,
        };
    }

    public IEnumerable<FindManyLocationsResponse> FindMany(IEnumerable<Location>? locations)
    {
        if (locations == null) return [];

        return from location in locations
            select new FindManyLocationsResponse()
            {
                Id = location.Id.ToString(),
                Description = location.Description,
                UnitId = location.UnitId.ToString(),
                UserId = location.UserId.ToString(),
                DepartmentId = location.DepartmentId.ToString(),
                DivisionId = location.DivisionId.ToString(),
            };
    }
}