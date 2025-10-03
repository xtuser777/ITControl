namespace ITControl.Domain.Users.Params;

public class ExclusiveUsersRepositoryParams
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
}
