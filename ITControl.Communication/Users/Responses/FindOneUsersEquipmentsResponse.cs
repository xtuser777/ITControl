namespace ITControl.Communication.Users.Responses;

public class FindOneUsersEquipmentsResponse
{
    public string Id { get; set; } = string.Empty;
    public string EquipmentId { get; set; } = string.Empty;
    public string StartedAt { get; set; } = string.Empty;
    public string? EndedAt { get; set; }
}