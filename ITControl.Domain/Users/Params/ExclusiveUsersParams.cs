namespace ITControl.Domain.Users.Params;

public class ExclusiveUsersParams : FindManyUsersParams
{
    public Guid ExcludeId { get; set; }
}
