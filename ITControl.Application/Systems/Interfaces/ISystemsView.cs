using ITControl.Communication.Systems.Responses;

namespace ITControl.Application.Systems.Interfaces;

public interface ISystemsView
{
    CreateSystemsResponse? Create(Domain.Systems.Entities.System? system);
    FindOneSystemsResponse? FindOne(Domain.Systems.Entities.System? system);
    IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Systems.Entities.System>? systems);
}