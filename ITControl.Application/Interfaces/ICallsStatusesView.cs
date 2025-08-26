using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Interfaces;

public interface ICallsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}