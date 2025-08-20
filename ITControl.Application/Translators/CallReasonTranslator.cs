using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;
public class CallReasonTranslator
{
    public static string ToDisplayValue(CallReason reason)
    {
        return reason switch
        {
            CallReason.SystemsUsers => "Gerenciar usuários de sistemas",
            CallReason.SystemsUsersPermissions => "Gerenciar permissões usuários de sistemas",
            CallReason.SoftwareInstallation => "Instalação de programas",
            CallReason.Network => "Problemas relacionados à internet",
            CallReason.Printer => "Problemas relacionados à impressoras",
            CallReason.Other => "Outro",
            _ => reason.ToString()
        };
    }
}
