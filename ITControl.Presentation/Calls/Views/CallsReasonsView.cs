using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Calls.Interfaces;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Calls.Views;

public class CallsReasonsView : ICallsReasonsView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var callsReasons = Enum.GetValues<CallReason>();
        return callsReasons.Select(cr => new TranslatableField()
        {
            Value = cr.ToString(),
            DisplayValue = cr.GetDisplayValue(),
        });
    }
}