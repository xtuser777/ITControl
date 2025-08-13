using ITControl.Communication.Users.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IUsersView
{
    CreateUsersResponse? Create(User? user);
    FindOneUsersResponse? FindOne(User? user);
    IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users);
}