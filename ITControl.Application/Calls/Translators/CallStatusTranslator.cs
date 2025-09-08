using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Calls.Enums;

namespace ITControl.Application.Calls.Translators;

public abstract class CallStatusTranslator
{
    public static string ToDisplayValue(CallStatus status)
    {
        return status switch
        {
            CallStatus.Open => CallsStatuses.Open,
            CallStatus.InProgress => CallsStatuses.InProgress,
            CallStatus.OnHold => CallsStatuses.OnHold,
            CallStatus.Closed => CallsStatuses.Closed,
            _ => status.ToString()
        };
    }
}
