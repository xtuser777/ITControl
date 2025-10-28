using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Presentation.SupplementsMovements.Responses;

namespace ITControl.Presentation.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsView
{
    CreateSupplementsMovementsResponse? Create(SupplementMovement? supplementMovement);
    FindOneSupplementsMovementsResponse? FindOne(SupplementMovement? supplementMovement);
    IEnumerable<FindManySupplementsMovementsResponse> FindMany(IEnumerable<SupplementMovement>? supplementMovements);
}
