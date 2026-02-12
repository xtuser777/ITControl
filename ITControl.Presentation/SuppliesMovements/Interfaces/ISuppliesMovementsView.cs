using ITControl.Domain.SuppliesMovements.Entities;
using ITControl.Presentation.SuppliesMovements.Responses;

namespace ITControl.Presentation.SuppliesMovements.Interfaces;

public interface ISuppliesMovementsView
{
    CreateSuppliesMovementsResponse? Create(SupplyMovement? supplyMovement);
    FindOneSuppliesMovementsResponse? FindOne(SupplyMovement? supplyMovement);
    IEnumerable<FindManySuppliesMovementsResponse> FindMany(IEnumerable<SupplyMovement>? supplyMovements);
}
