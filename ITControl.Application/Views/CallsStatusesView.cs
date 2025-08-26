using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Enums;

namespace ITControl.Application.Views;

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