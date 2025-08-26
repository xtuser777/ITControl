using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface ICallsReasonsView
{
    IEnumerable<TranslatableField> FindMany();
}