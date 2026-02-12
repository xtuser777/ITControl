using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Supplies.Interfaces;

public interface ISuppliesTypesView
{
    IEnumerable<TranslatableField> FindMany();
}
