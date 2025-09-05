using ITControl.Application.Users.Interfaces;
using ITControl.Communication.Users.Responses;
using ITControl.Domain.Users.Entities;

namespace ITControl.Application.Users.Views;

public class UsersView : IUsersView
{
    public CreateUsersResponse? Create(User? user)
    {
        if (user == null)
        {
            return null;
        }

        return new CreateUsersResponse()
        {
            Id = user.Id
        };
    }

    public FindOneUsersResponse? FindOne(User? user)
    {
        if (user == null)
        {
            return null;
        }

        return new FindOneUsersResponse()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Username = user.Username,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId,
            RoleId = user.RoleId,
            Position = user.Position != null
                ? new FindOneUsersPositionResponse()
                {
                    Id = user.PositionId,
                    Description = user.Position.Description,
                }
                : null,
            Role = user.Role != null
                ? new FindOneUsersRoleResponse()
                {
                    Id = user.RoleId,
                    Name = user.Role.Name,
                } 
                : null,
            UsersEquipments = user.UsersEquipments != null 
                ? from equipment in user.UsersEquipments select 
                    new FindOneUsersEquipmentsResponse()
                    {
                        Id = equipment.Id,
                        EquipmentId = equipment.EquipmentId,
                        StartedAt = equipment.StartedAt,
                        EndedAt = equipment.EndedAt,
                    }
                    : null,
            UsersSystems = user.UsersSystems != null
                ? from system in user.UsersSystems select
                    new FindOneUsersSystemsResponse()
                    {
                        Id = system.Id,
                        SystemId = system.SystemId,
                    }
                : null,
        };
    }

    public IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users)
    {
        if (users == null) return [];

        return from user in users select new FindManyUsersResponse()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Username = user.Username,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId,
            RoleId = user.RoleId,
        };
    }
}