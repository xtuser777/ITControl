using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Calls.Interfaces;

public interface ICallsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}