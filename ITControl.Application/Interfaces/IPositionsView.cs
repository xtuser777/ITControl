using ITControl.Communication.Positions.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPositionsView
{
    FindOnePositionsResponse? FindOne(Position? position);
    IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions);
    CreatePositionsResponse? Create(Position? position);
}