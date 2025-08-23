namespace ITControl.Communication.Users.Requests;

public class CreateUsersEquipmentsRequest
{
    public Guid EquipmentId { get; set; }
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
}