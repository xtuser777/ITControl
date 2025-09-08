using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Equipments.Enums;

namespace ITControl.Application.Equipments.Translators;

public abstract class EquipmentTypeTranslator
{
    public static string ToDisplayValue(EquipmentType equipmentType)
    {
        return equipmentType switch
        {
            EquipmentType.Desktop => EquipmentsTypes.Desktop,
            EquipmentType.Laptop => EquipmentsTypes.Laptop,
            EquipmentType.Server => EquipmentsTypes.Server,
            EquipmentType.Printer => EquipmentsTypes.Printer,
            EquipmentType.Router => EquipmentsTypes.Router,
            EquipmentType.Switch => EquipmentsTypes.Switch,
            EquipmentType.Firewall => EquipmentsTypes.Firewall,
            EquipmentType.Cftv => EquipmentsTypes.Cftv,
            EquipmentType.Pabx => EquipmentsTypes.Pabx,
            EquipmentType.TimeClock => EquipmentsTypes.TimeClock,
            EquipmentType.Other => EquipmentsTypes.Other,
            _ => equipmentType.ToString()
        };
    }
}