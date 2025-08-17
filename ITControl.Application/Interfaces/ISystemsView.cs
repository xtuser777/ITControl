using ITControl.Communication.Systems.Responses;

namespace ITControl.Application.Interfaces;

public interface ISystemsView
{
    CreateSystemsResponse? Create(Domain.Entities.System? system);
    FindOneSystemsResponse? FindOne(Domain.Entities.System? system);
    IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Entities.System>? systems);
}