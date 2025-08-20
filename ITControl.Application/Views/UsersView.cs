using ITControl.Application.Interfaces;
using ITControl.Communication.Users.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

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
            Id = user.Id.ToString()
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
            Id = user.Id.ToString(),
            Name = user.Name,
            Email = user.Email,
            Username = user.Username,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId.ToString(),
            RoleId = user.RoleId.ToString(),
            Position = user.Position != null
                ? new FindOneUsersPositionResponse()
                {
                    Id = user.PositionId.ToString(),
                    Description = user.Position.Description,
                }
                : null,
            Role = user.Role != null
                ? new FindOneUsersRoleResponse()
                {
                    Id = user.RoleId.ToString(),
                    Name = user.Role.Name,
                } 
                : null,
            UsersEquipments = user.UsersEquipments != null 
                ? from equipment in user.UsersEquipments select 
                    new FindOneUsersEquipmentsResponse()
                    {
                        Id = equipment.Id.ToString(),
                        EquipmentId = equipment.EquipmentId.ToString(),
                        StartedAt = equipment.StartedAt.ToString(),
                        EndedAt = equipment.EndedAt.ToString(),
                    }
                    : null,
            UsersSystems = user.UsersSystems != null
                ? from system in user.UsersSystems select
                    new FindOneUsersSystemsResponse()
                    {
                        Id = system.Id.ToString(),
                        SystemId = system.SystemId.ToString(),
                    }
                : null,
        };
    }

    public IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users)
    {
        if (users == null) return [];

        return from user in users select new FindManyUsersResponse()
        {
            Id = user.Id.ToString(),
            Name = user.Name,
            Email = user.Email,
            Username = user.Username,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId.ToString(),
            RoleId = user.RoleId.ToString(),
        };
    }
}