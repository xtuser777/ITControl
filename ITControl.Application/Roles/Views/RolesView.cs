using ITControl.Application.Roles.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Roles.Responses;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Application.Roles.Views;

public class RolesView : IRolesView
{
    public CreateRolesResponse? Create(Role? role)
    {
        if (role == null) return null;

        return new CreateRolesResponse()
        {
            Id = role.Id,
        };
    }

    public FindOneRolesResponse? FindOne(Role? role)
    {
        if (role == null) return null;

        return new FindOneRolesResponse()
        {
            Id = role.Id,
            Name = role.Name,
            Active = role.Active,
            RolesPages = role.RolesPages != null 
                ? from rolePage in role.RolesPages 
                    select new FindOneRolesPagesResponse()
                    {
                        Id = rolePage.Id,
                        PageId = rolePage.PageId,
                    }
                    : null,
            Pages = role.RolesPages != null 
                ? from rolePage in role.RolesPages 
                    select new FindOneRolesPageResponse()
                    {
                        Id = rolePage.Page?.Id ?? Guid.Empty,
                        Name = rolePage.Page?.Name ?? string.Empty,
                        DisplayValue = PagesTranslator.ToDisplayValue(rolePage.Page?.Name ?? "")
                    }
                    : null,
        };
    }

    public IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles)
    {
        if (roles == null) return [];

        return from role in roles
            select new FindManyRolesResponse()
            {
                Id = role.Id,
                Name = role.Name,
                Active = role.Active,
            };
    }
}