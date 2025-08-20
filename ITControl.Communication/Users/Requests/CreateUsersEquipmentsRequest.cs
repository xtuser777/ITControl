namespace ITControl.Communication.Users.Requests;

public class CreateUsersEquipmentsRequest
{
    public string EquipmentId { get; set; } = string.Empty;
    public string StartedAt { get; set; } = string.Empty;
    public string? EndedAt { get; set; }
}