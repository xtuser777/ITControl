namespace ITControl.Application.Translators;

public class PagesTranslator
{
    public static string ToDisplayValue(string value)
    {
        return value switch
        {
            "pages" => "Páginas",
            "roles" => "Perfis",
            "positions" => "Cargos",
            "users" => "Usuários",
            "contracts" => "Contratos",
            "equipments" => "Equipamentos",
            "systems" => "Sistemas",
            "units" => "Unidades",
            "departments" => "Secretarias",
            "divisions" => "Divisões",
            "locations" => "Localizações",
            "calls" => "Chamados",
            "appointments" => "Agendamentos",
            "treatments" => "Atendimentos",
            "notifications" => "Notificações",
            _ => value,
        };
    }
}