using ITControl.Communication.Locations.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface ILocationsView
{
    CreateLocationsResponse? Create(Location? location);
    FindOneLocationsResponse? FindOne(Location? location);
    IEnumerable<FindManyLocationsResponse> FindMany(IEnumerable<Location>? location);
}