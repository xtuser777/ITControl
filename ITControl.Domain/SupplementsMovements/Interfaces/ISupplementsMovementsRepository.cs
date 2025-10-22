using ITControl.Domain.Shared.Interfaces;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Domain.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsRepository : 
    IRepository<SupplementMovement>
{
}
