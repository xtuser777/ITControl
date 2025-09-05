using ITControl.Communication.Users.Responses;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Interfaces;

public interface IUsersView
{
    CreateUsersResponse? Create(User? user);
    FindOneUsersResponse? FindOne(User? user);
    IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users);
}