using ITControl.Domain.Units.Props;

namespace ITControl.Domain.Units.Entities;

public sealed class Unit : UnitProps
{
    public Unit()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Unit(UnitProps @params)
    {
        Assign(@params);
    }


    public void Update(UnitProps @params)
    {
        AssignUpdate(@params);
    }
}