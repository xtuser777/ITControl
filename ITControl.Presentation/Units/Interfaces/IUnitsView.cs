using ITControl.Domain.Units.Entities;
using ITControl.Presentation.Units.Responses;

namespace ITControl.Presentation.Units.Interfaces;

public interface IUnitsView
{
    CreateUnitsResponse? Create(Unit? unit);
    FindOneUnitsResponse? FindOne(Unit? unit);
    IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units);
}