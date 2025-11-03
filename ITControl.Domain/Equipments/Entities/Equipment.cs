using ITControl.Domain.Equipments.Props;

namespace ITControl.Domain.Equipments.Entities;

public sealed class Equipment : EquipmentProps
{
    public Equipment()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Equipment(EquipmentProps @params)
    {
        Assign(@params);
    }

    public void Update(EquipmentProps @params)
    {
        AssignUpdate(@params);
    }
}