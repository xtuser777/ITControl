using ITControl.Domain.Users.Entities;
using ITControl.Presentation.Users.Interfaces;
using ITControl.Presentation.Users.Responses;

namespace ITControl.Presentation.Users.Views;

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
            Document = user.Document,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId,
            RoleId = user.RoleId,
            UnitId = user.UnitId,
            DepartmentId = user.DepartmentId,
            DivisionId = user.DivisionId,
            Position = user.Position != null
                ? new FindOneUsersPositionResponse()
                {
                    Id = user.PositionId,
                    Description = user.Position.Name,
                }
                : null,
            Role = user.Role != null
                ? new FindOneUsersRoleResponse()
                {
                    Id = user.RoleId,
                    Name = user.Role.Name,
                } 
                : null,
            Unit = user.Unit is not null
                ? new FindOneUsersUnitResponse()
                {
                    Id = user.UnitId,
                    Name = user.Unit.Name,
                    Address = $"{user.Unit.StreetName}, {user.Unit.AddressNumber}, {user.Unit.Neighborhood}",
                    Phone = user.Unit.Phone,
                    Email = ""
                }
                : null,
            Department = user.Department is not null
                ? new FindOneUsersDepartmentResponse()
                {
                    Id = user.DepartmentId,
                    Name = user.Department.Name,
                    Alias = user.Department.Alias,
                }
                : null,
            Division = user.Division is not null
                ? new FindOneUsersDivisionResponse()
                {
                    Id = user.Division.Id,
                    Name = user.Division.Name,
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
            Document = user.Document,
            Enrollment = user.Enrollment,
            Active = user.Active,
            PositionId = user.PositionId,
            RoleId = user.RoleId,
            UnitId = user.UnitId,
            DepartmentId = user.DepartmentId,
            DivisionId = user.DivisionId,
        };
    }
}