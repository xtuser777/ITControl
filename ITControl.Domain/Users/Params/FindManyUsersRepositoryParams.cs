namespace ITControl.Domain.Users.Params;

public class FindManyUsersRepositoryParams
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
    public int? Enrollment { get; set; }
    public bool? Active { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public string? OrderByUsername { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByEmail { get; set; }
    public string? OrderByDocument { get; set; }
    public string? OrderByEnrollment { get; set; }
    public string? OrderByActive { get; set; }
    public string? OrderByPosition { get; set; }
    public string? OrderByRole { get; set; }
    public string? OrderByUnit { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByDivision { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountUsersRepositoryParams(FindManyUsersRepositoryParams @params) =>
        new ()
        {
            Username = @params.Username,
            Name = @params.Name,
            Email = @params.Email,
            Document = @params.Document,
            Enrollment = @params.Enrollment,
            Active = @params.Active,
            PositionId = @params.PositionId,
            RoleId = @params.RoleId,
            UnitId = @params.UnitId,
            DepartmentId = @params.DepartmentId,
            DivisionId = @params.DivisionId,
        };
}