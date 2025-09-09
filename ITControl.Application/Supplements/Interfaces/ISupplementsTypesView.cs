using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Supplements.Interfaces;

public interface ISupplementsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
