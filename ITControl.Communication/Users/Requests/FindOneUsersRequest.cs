using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public class FindOneUsersRequest
{
    public Guid Id { get; set; }
    public bool? IncludePosition { get; set; } = true;
    public bool? IncludeRole { get; set; } = true;
    public bool? IncludeUnit { get; set; } = true;
    public bool? IncludeDepartment { get; set; } = true;
    public bool? IncludeDivision { get; set; } = true;
    public bool? IncludeUsersSystems { get; set; } = true;
    public bool? IncludeUsersEquipments { get; set; } = true;

    public static implicit operator FindOneUsersRepositoryParams(FindOneUsersRequest request) =>
        new ()
        {
            Id = request.Id,
            IncludePosition = request.IncludePosition,
            IncludeRole = request.IncludeRole,
            IncludeUnit = request.IncludeUnit,
            IncludeDepartment = request.IncludeDepartment,
            IncludeDivision = request.IncludeDivision,
            IncludeUsersSystems = request.IncludeUsersSystems,
            IncludeUsersEquipments = request.IncludeUsersEquipments,
        };
}
