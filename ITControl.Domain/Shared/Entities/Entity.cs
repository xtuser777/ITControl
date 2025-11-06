using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared.Entities;

public abstract class Entity
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    protected void Assign(Entity entity)
    {
        var selfProperties = this.GetType().GetProperties();
        var entityProperties = entity.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            prop.SetValue(this, prop.GetValue(entity));
        }
        Id = Guid.NewGuid(); 
        CreatedAt = DateTime.Now;   
        UpdatedAt = DateTime.Now;
    }
    
    protected void AssignUpdate(Entity entity)
    {
        var selfProperties = this.GetType().GetProperties();
        var entityProperties = entity.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            switch (prop.Name)
            {
                case nameof(Id):
                case nameof(CreatedAt):
                case nameof(UpdatedAt):
                    continue;
                default:
                    if (prop.GetValue(entity) is not null)
                        prop.SetValue(this, prop.GetValue(entity));
                    break;
            }
        }
        UpdatedAt = DateTime.Now;
    }
}