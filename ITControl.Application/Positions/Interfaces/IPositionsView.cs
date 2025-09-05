using ITControl.Communication.Positions.Responses;
using ITControl.Domain.Positions.Entities;

namespace ITControl.Application.Positions.Interfaces;

public interface IPositionsView
{
    FindOnePositionsResponse? FindOne(Position? position);
    IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions);
    CreatePositionsResponse? Create(Position? position);
}