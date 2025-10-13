using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Positions.Entities;

public sealed class Position : Entity
{
    public Position() {}
    
    public Position(PositionParams @params)
    {
        Id = Guid.NewGuid();
        Description = @params.Description;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Description { get; set; } = string.Empty;

    public void Update(UpdatePositionParams @params)
    {
        Description = @params.Description ?? Description;
        UpdatedAt = DateTime.Now;
    }
}