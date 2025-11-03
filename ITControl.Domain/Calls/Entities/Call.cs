using ITControl.Domain.Calls.Props;

namespace ITControl.Domain.Calls.Entities;

public sealed class Call : CallProps
{
    public Call()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Call(CallProps props)
    {
        Assign(props);
    }
}