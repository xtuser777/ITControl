using ITControl.Domain.Positions.Props;

namespace ITControl.Domain.Positions.Entities;

public sealed class Position : PositionProps
{
    public Position()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Position(PositionProps props)
    {
        Assign(props);
    }

    public void Update(PositionProps props)
    {
        Name = props.Name;
        UpdatedAt = DateTime.Now;
    }
}