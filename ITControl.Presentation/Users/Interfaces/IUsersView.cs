using ITControl.Domain.Users.Entities;
using ITControl.Presentation.Users.Responses;

namespace ITControl.Presentation.Users.Interfaces;

public interface IUsersView
{
    CreateUsersResponse? Create(User? user);
    FindOneUsersResponse? FindOne(User? user);
    IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users);
}