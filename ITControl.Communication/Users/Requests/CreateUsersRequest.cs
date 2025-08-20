namespace ITControl.Communication.Users.Requests;

public class CreateUsersRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Enrollment { get; set; }
    public string PositionId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;
    public IEnumerable<CreateUsersEquipmentsRequest> Equipments { get; set; } = [];
    public IEnumerable<CreateUsersSystemsRequest> Systems { get; set; } = [];
}