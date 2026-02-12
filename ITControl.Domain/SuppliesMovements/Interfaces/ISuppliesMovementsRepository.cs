using ITControl.Domain.Shared.Interfaces;
using ITControl.Domain.SuppliesMovements.Entities;

namespace ITControl.Domain.SuppliesMovements.Interfaces;

public interface ISuppliesMovementsRepository : 
    IRepository<SupplyMovement>
{
}
