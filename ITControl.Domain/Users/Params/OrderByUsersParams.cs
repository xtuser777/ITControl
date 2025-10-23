using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Users.Params;

public record OrderByUsersParams : OrderByParams
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
    public string? Enrollment { get; set; }
    public string? Active { get; set; }
    public string? Position { get; set; }
    public string? Role { get; set; }
    public string? Unit { get; set; }
    public string? Department { get; set; }
    public string? Division { get; set; }
}