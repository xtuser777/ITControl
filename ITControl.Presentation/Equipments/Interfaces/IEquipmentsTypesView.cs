using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Equipments.Interfaces;

public interface IEquipmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
