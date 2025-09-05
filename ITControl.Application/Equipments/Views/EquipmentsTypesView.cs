using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Equipments.Views;

public class EquipmentsTypesView : IEquipmentsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var equipmentTypes = Enum.GetValues<Domain.Enums.EquipmentType>();
        return equipmentTypes.Select(et => new TranslatableField
        {
            Value = et.ToString(),
            DisplayValue = EquipmentTypeTranslator.ToDisplayValue(et)
        });
    }
}
