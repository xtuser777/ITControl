namespace ITControl.Presentation.Calls.Responses;
public class FindOneCallsEquipmentResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? Ip { get; set; } = string.Empty;
    public string? Mac { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
}
