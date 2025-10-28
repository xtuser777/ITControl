using ITControl.Domain.Positions.Entities;
using ITControl.Presentation.Positions.Responses;

namespace ITControl.Presentation.Positions.Interfaces;

public interface IPositionsView
{
    FindOnePositionsResponse? FindOne(Position? position);
    IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions);
    CreatePositionsResponse? Create(Position? position);
}