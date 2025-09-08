using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Calls.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Enums;

namespace ITControl.Application.Calls.Views;

public class CallsReasonsView : ICallsReasonsView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var callsReasons = Enum.GetValues<CallReason>();
        return callsReasons.Select(cr => new TranslatableField()
        {
            Value = cr.ToString(),
            DisplayValue = CallReasonTranslator.ToDisplayValue(cr),
        });
    }
}