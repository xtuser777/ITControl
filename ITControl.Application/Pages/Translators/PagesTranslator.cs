namespace ITControl.Application.Pages.Translators;

public abstract class PagesTranslator
{
    public static string ToDisplayValue(string value)
    {
        return value switch
        {
            "pages" => Shared.Messages.Translate.PagesNames.Pages,
            "roles" => Shared.Messages.Translate.PagesNames.Roles,
            "positions" => Shared.Messages.Translate.PagesNames.Positions,
            "users" => Shared.Messages.Translate.PagesNames.Users,
            "contracts" => Shared.Messages.Translate.PagesNames.Contracts,
            "equipments" => Shared.Messages.Translate.PagesNames.Equipments,
            "systems" => Shared.Messages.Translate.PagesNames.Systems,
            "units" => Shared.Messages.Translate.PagesNames.Units,
            "departments" => Shared.Messages.Translate.PagesNames.Departments,
            "divisions" => Shared.Messages.Translate.PagesNames.Divisions,
            "locations" => Shared.Messages.Translate.PagesNames.Locations,
            "calls" => Shared.Messages.Translate.PagesNames.Calls,
            "appointments" => Shared.Messages.Translate.PagesNames.Appointments,
            "treatments" => Shared.Messages.Translate.PagesNames.Treatments,
            "notifications" => Shared.Messages.Translate.PagesNames.Notifications,
            _ => value,
        };
    }
}