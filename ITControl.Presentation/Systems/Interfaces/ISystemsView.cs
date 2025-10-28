using ITControl.Presentation.Systems.Responses;

namespace ITControl.Presentation.Systems.Interfaces;

public interface ISystemsView
{
    CreateSystemsResponse? Create(Domain.Systems.Entities.System? system);
    FindOneSystemsResponse? FindOne(Domain.Systems.Entities.System? system);
    IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Systems.Entities.System>? systems);
}