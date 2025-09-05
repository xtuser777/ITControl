using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Calls.Interfaces;

public interface ICallsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}