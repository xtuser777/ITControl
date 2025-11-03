using ITControl.Domain.SupplementsMovements.Props;

namespace ITControl.Domain.SupplementsMovements.Entities;

public sealed class SupplementMovement : SupplementMovementProps
{
    public SupplementMovement() { }
    
    public SupplementMovement(SupplementMovementProps @params)
    {
        Assign(@params);
    }

    public void Update(SupplementMovementProps @params)
    {
        AssignUpdate(@params);
    }
}
