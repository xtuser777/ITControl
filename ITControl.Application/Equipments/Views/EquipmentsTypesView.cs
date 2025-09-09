using ITControl.Application.Equipments.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Shared.Extensions;

namespace ITControl.Application.Equipments.Views;

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
