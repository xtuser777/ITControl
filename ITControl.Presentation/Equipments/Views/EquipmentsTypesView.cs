using ITControl.Presentation.Equipments.Interfaces;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Equipments.Views;

public class EquipmentsTypesView : IEquipmentsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var equipmentTypes = Enum.GetValues<EquipmentType>();
        return equipmentTypes.Select(et => new TranslatableField
        {
            Value = et.ToString(),
            DisplayValue = et.GetDisplayValue()
        });
    }
}
