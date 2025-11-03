using ITControl.Presentation.Systems.Responses;

namespace ITControl.Presentation.Systems.Interfaces;

public interface ISystemsView
{
    CreateSystemsResponse? Create(Domain.Systems.Entities.SystemEntity? system);
    FindOneSystemsResponse? FindOne(Domain.Systems.Entities.SystemEntity? system);
    IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Systems.Entities.SystemEntity>? systems);
}