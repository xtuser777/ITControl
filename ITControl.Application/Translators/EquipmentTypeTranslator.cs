using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class EquipmentTypeTranslator
{
    public static string ToDisplayValue(EquipmentType equipmentType)
    {
        return equipmentType switch
        {
            EquipmentType.Desktop => "Computador de mesa",
            EquipmentType.Laptop => "Notebook",
            EquipmentType.Server => "Servidor",
            EquipmentType.Printer => "Impressora",
            EquipmentType.Router => "Roteador",
            EquipmentType.Switch => "Switch",
            EquipmentType.Firewall => "Firewall",
            EquipmentType.Cftv => "CFTV",
            EquipmentType.Pabx => "PABX",
            EquipmentType.TimeClock => "Relógio de ponto",
            EquipmentType.Other => "Outro",
            _ => equipmentType.ToString()
        };
    }
}