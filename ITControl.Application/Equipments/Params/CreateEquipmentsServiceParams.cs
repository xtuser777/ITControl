using ITControl.Domain.Equipments.Params;

namespace ITControl.Application.Equipments.Params;

public record CreateEquipmentsServiceParams
{
    public EquipmentParams Params { get; set; } = null!;
}