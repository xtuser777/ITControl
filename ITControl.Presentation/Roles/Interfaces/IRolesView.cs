using ITControl.Domain.Roles.Entities;
using ITControl.Presentation.Roles.Responses;

namespace ITControl.Presentation.Roles.Interfaces;

public interface IRolesView
{
    CreateRolesResponse? Create(Role? role);
    FindOneRolesResponse? FindOne(Role? role);
    IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles);
}