using ITControl.Communication.Units.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IUnitsView
{
    CreateUnitsResponse? Create(Unit? unit);
    FindOneUnitsResponse? FindOne(Unit? unit);
    IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units);
}