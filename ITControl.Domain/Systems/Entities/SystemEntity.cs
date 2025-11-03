using ITControl.Domain.Systems.Props;

namespace ITControl.Domain.Systems.Entities;

public class SystemEntity : SystemProps
{
    public SystemEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public SystemEntity(SystemProps @params)
    {
        Assign(@params);
    }

    public void Update(SystemProps @params)
    {
        AssignUpdate(@params);
    }
}