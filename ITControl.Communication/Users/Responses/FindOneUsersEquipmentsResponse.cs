namespace ITControl.Communication.Users.Responses;

public class FindOneUsersEquipmentsResponse
{
    public Guid Id { get; set; }
    public Guid EquipmentId { get; set; }
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
}