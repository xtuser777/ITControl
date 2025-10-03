using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Params;

public class BuildOrderByUsersRepositoryParams
{
    public IQueryable<User> Query { get; set; } = null!;
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
}
