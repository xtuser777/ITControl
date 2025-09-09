using ITControl.Communication.SupplementsMovements.Responses;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsView
{
    CreateSupplementsMovementsResponse? Create(SupplementMovement? supplementMovement);
    FindOneSupplementsMovementsResponse? FindOne(SupplementMovement? supplementMovement);
    IEnumerable<FindManySupplementsMovementsResponse> FindMany(IEnumerable<SupplementMovement>? supplementMovements);
}
