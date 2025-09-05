using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Equipments.Interfaces;

public interface IEquipmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
