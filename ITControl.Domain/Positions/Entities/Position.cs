using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Positions.Entities;

public sealed class Position : Entity
{
    public Position() {}
    
    public Position(PositionParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name { get; set; } = string.Empty;

    public void Update(UpdatePositionParams @params)
    {
        Name = @params.Name ?? Name;
        UpdatedAt = DateTime.Now;
    }
}