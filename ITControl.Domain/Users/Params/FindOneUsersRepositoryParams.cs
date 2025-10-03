namespace ITControl.Domain.Users.Params;

public class FindOneUsersRepositoryParams
{
    public Guid? Id { get; set; } = null;
    public bool? IncludePosition { get; set; } = null;
    public bool? IncludeRole { get; set; }
    public bool? IncludeUnit { get; set; }
    public bool? IncludeDepartment { get; set; }
    public bool? IncludeDivision { get; set; }
    public bool? IncludeUsersSystems { get; set; }
    public bool? IncludeUsersEquipments { get; set; }
}
