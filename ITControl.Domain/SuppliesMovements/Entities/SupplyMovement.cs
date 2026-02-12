using ITControl.Domain.SuppliesMovements.Props;

namespace ITControl.Domain.SuppliesMovements.Entities;

public sealed class SupplyMovement : SupplyMovementProps
{
    public SupplyMovement() { }
    
    public SupplyMovement(SupplyMovementProps @params)
    {
        Assign(@params);
    }

    public void Update(SupplyMovementProps @params)
    {
        AssignUpdate(@params);
    }
}
