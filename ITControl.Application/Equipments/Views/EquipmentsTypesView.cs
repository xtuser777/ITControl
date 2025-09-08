using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Equipments.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Enums;

namespace ITControl.Application.Equipments.Views;

public class EquipmentsTypesView : IEquipmentsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var equipmentTypes = Enum.GetValues<EquipmentType>();
        return equipmentTypes.Select(et => new TranslatableField
        {
            Value = et.ToString(),
            DisplayValue = EquipmentTypeTranslator.ToDisplayValue(et)
        });
    }
}
