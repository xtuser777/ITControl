using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Calls.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Enums;

namespace ITControl.Application.Calls.Views;

public class CallsStatusesView : ICallsStatusesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var callsStatuses = Enum.GetValues<CallStatus>();
        return callsStatuses.Select(cs => new TranslatableField()
        {
            Value = cs.ToString(),
            DisplayValue = CallStatusTranslator.ToDisplayValue(cs),
        });
    }
}