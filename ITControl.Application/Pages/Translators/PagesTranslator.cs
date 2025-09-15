using ITControl.Application.Shared.Messages.Translate;

namespace ITControl.Application.Pages.Translators;

public abstract class PagesTranslator
{
    public static string ToDisplayValue(string value)
    {
        return value switch
        {
            "pages" => PagesNames.Pages,
            "roles" => PagesNames.Roles,
            "positions" => PagesNames.Positions,
            "users" => PagesNames.Users,
            "contracts" => PagesNames.Contracts,
            "equipments" => PagesNames.Equipments,
            "systems" => PagesNames.Systems,
            "units" => PagesNames.Units,
            "departments" => PagesNames.Departments,
            "divisions" => PagesNames.Divisions,
            "locations" => PagesNames.Locations,
            "calls" => PagesNames.Calls,
            "appointments" => PagesNames.Appointments,
            "treatments" => PagesNames.Treatments,
            "notifications" => PagesNames.Notifications,
            _ => value,
        };
    }
}