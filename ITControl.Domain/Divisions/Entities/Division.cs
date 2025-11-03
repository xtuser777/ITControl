using ITControl.Domain.Divisions.Props;

namespace ITControl.Domain.Divisions.Entities;

public sealed class Division : DivisionProps
{
    public Division() {}

    public Division(DivisionProps props)
    {
        Assign(props);
    }

    public void Update(DivisionProps props)
    {
        AssignUpdate(props);
    }
}