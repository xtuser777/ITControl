using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Calls.Interfaces;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Calls.Views;

public class CallsStatusesView : ICallsStatusesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var callsStatuses = Enum.GetValues<CallStatus>();
        return callsStatuses.Select(cs => new TranslatableField()
        {
            Value = cs.ToString(),
            DisplayValue = cs.GetDisplayValue(),
        });
    }
}