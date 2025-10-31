using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    protected void Assign(Entity entity)
    {
        var selfProperties = this.GetType().GetProperties();
        var entityProperties = entity.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            prop.SetValue(this, prop.GetValue(entity));
        }
    }
    
    public Entity Convert(EntityParams parameters)
    {
        var selfProperties = this.GetType().GetProperties();
        var parametersProperties = parameters.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            prop.SetValue(this, prop.GetValue(parameters));
        }

        return this;
    }
}