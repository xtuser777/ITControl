using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Params;

public class BuildQueryUsersRepositoryParams : CountUsersRepositoryParams
{
    public IQueryable<User> Query { get; set; } = null!;
}
