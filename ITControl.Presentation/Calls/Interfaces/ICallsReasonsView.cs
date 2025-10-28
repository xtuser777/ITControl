using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Calls.Interfaces;

public interface ICallsReasonsView
{
    IEnumerable<TranslatableField> FindMany();
}