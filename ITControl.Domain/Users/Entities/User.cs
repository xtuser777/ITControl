using ITControl.Domain.Users.Props;

namespace ITControl.Domain.Users.Entities;

public sealed class User : UserProps
{
    public User() 
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public User(UserProps @params)
    {
        Assign(@params);
        Active = true;
    }

    public void Update(UserProps @params)
    {
        AssignUpdate(@params);
    }
}