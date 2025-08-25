using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Views;

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
