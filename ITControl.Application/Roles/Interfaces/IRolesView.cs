using ITControl.Communication.Roles.Responses;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Application.Roles.Interfaces;

public interface IRolesView
{
    CreateRolesResponse? Create(Role? role);
    FindOneRolesResponse? FindOne(Role? role);
    IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles);
}