using ITControl.Domain.Supplies.Props;

namespace ITControl.Domain.Supplies.Entities;

public sealed class Supply : SupplyProps
{
    public Supply()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Supply(SupplyProps @params)
    {
        Assign(@params);
    }

    public void Update(SupplyProps @params)
    {
        AssignUpdate(@params);
    }
}
