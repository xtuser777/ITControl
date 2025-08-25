using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface IEquipmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
