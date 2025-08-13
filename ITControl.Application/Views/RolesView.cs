using ITControl.Application.Interfaces;
using ITControl.Communication.Roles.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class RolesView : IRolesView
{
    public CreateRolesResponse? Create(Role? role)
    {
        if (role == null) return null;

        return new CreateRolesResponse()
        {
            Id = role.Id.ToString(),
        };
    }

    public FindOneRolesResponse? FindOne(Role? role)
    {
        if (role == null) return null;

        return new FindOneRolesResponse()
        {
            Id = role.Id.ToString(),
            Name = role.Name,
            Active = role.Active,
            RolesPages = role.RolesPages != null ? from rolePage in role.RolesPages select new FindOneRolesPagesResponse()
            {
                Id = rolePage.Id.ToString(),
                PageId = rolePage.PageId.ToString(),
                Page = rolePage.Page != null ? new FindOneRolesPagesPageResponse()
                {
                    Id = rolePage.PageId.ToString(),
                    Name = rolePage.Page.Name,
                } : null,
            }: null,
        };
    }

    public IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles)
    {
        if (roles == null) return [];

        return from role in roles
            select new FindManyRolesResponse()
            {
                Id = role.Id.ToString(),
                Name = role.Name,
                Active = role.Active,
            };
    }
}