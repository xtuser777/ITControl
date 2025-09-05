using ITControl.Communication.Units.Responses;
using ITControl.Domain.Units.Entities;

namespace ITControl.Application.Units.Interfaces;

public interface IUnitsView
{
    CreateUnitsResponse? Create(Unit? unit);
    FindOneUnitsResponse? FindOne(Unit? unit);
    IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units);
}