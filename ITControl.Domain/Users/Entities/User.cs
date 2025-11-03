using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Users.Props;

namespace ITControl.Domain.Users.Entities;

public sealed class User : UserProps
{
    public User() { }

    public User(UserProps @params)
    {
        Assign(@params);
        Password = Crypt.HashPassword(@params.Password!);
        Active = true;
    }

    public void Update(UserProps @params)
    {
        AssignUpdate(@params);
        Password = Crypt.HashPassword(@params.Password ?? Password!);
    }
}