using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Calls.Interfaces;

public interface ICallsReasonsView
{
    IEnumerable<TranslatableField> FindMany();
}