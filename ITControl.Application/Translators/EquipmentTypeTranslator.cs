using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class EquipmentTypeTranslator
{
    public static string ToDisplayValue(EquipmentType equipmentType)
    {
        return equipmentType switch
        {
            EquipmentType.Desktop => "Computador de mesa",
            EquipmentType.Notebook => "Notebook",
            EquipmentType.Server => "Servidor",
            _ => equipmentType.ToString()
        };
    }
}