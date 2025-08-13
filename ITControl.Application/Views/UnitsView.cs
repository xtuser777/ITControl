using ITControl.Application.Interfaces;
using ITControl.Communication.Units.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class UnitsView : IUnitsView
{
    public CreateUnitsResponse? Create(Unit? unit)
    {
        if (unit is null) return null;

        return new CreateUnitsResponse()
        {
            Id = unit.Id.ToString(),
        };
    }

    public FindOneUnitsResponse? FindOne(Unit? unit)
    {
        if (unit is null) return null;

        return new FindOneUnitsResponse()
        {
            Id = unit.Id.ToString(),
            Name = unit.Name,
            Phone = unit.Phone,
            PostalCode = unit.PostalCode,
            StreetName = unit.StreetName,
            AddressNumber = unit.AddressNumber,
            Neighborhood = unit.Neighborhood,
            UnitsDepartments = [],
            UnitsDivisions = [],
        };
    }

    public IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units)
    {
        if (units is null) return [];

        return from unit in units select new FindManyUnitsResponse()
        {
            Id = unit.Id.ToString(),
            Name = unit.Name,
            Phone = unit.Phone,
            PostalCode = unit.PostalCode,
            StreetName = unit.StreetName,
            AddressNumber = unit.AddressNumber,
            Neighborhood = unit.Neighborhood,
        };
    }
}