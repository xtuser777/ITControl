using ITControl.Communication.Locations.Responses;
using ITControl.Domain.Locations.Entities;

namespace ITControl.Application.Locations.Interfaces;

public interface ILocationsView
{
    CreateLocationsResponse? Create(Location? location);
    FindOneLocationsResponse? FindOne(Location? location);
    IEnumerable<FindManyLocationsResponse> FindMany(IEnumerable<Location>? location);
}