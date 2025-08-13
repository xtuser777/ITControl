using ITControl.Communication.Roles.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IRolesView
{
    CreateRolesResponse? Create(Role? role);
    FindOneRolesResponse? FindOne(Role? role);
    IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles);
}