namespace ITControl.Domain.Users.Params;

public record CountUsersParams : FindManyUsersParams
{
    public Guid? Id { get; init; }
}
