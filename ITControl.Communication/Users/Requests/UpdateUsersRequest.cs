namespace ITControl.Communication.Users.Requests;

public class UpdateUsersRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool? Active { get; set; }
    public int? Enrollment { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RoleId { get; set; }
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}