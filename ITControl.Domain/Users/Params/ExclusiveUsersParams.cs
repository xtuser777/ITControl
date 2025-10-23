namespace ITControl.Domain.Users.Params;

public record ExclusiveUsersParams : FindManyUsersParams
{
    public Guid ExcludeId { get; set; }
}
