using ITControl.Domain.Calls.Props;

namespace ITControl.Domain.Calls.Entities;

public sealed class CallStatus : CallStatusProps
{
    public CallStatus()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    public CallStatus(CallStatusProps @params)
    {
        Assign(@params);
    }

    public void Update(CallStatusProps @params)
    {
        AssignUpdate(@params);
    }
}
