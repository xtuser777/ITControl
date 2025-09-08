using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Calls.Enums;

namespace ITControl.Application.Calls.Translators;

public abstract class CallReasonTranslator
{
    public static string ToDisplayValue(CallReason reason)
    {
        return reason switch
        {
            CallReason.SystemsUsers => CallsReasons.SystemsUsers,
            CallReason.SystemsUsersPermissions => CallsReasons.SystemsUsersPermissions,
            CallReason.SoftwareInstallation => CallsReasons.SoftwareInstallation,
            CallReason.Network => CallsReasons.Network,
            CallReason.Printer => CallsReasons.Printer,
            CallReason.Other => CallsReasons.Other,
            _ => reason.ToString()
        };
    }
}
