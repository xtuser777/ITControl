using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Supplements.Interfaces;

public interface ISupplementsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
