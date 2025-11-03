namespace ITControl.Presentation.Treatments.Responses;

public class FindOneTreatmentsCallUserResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Unit { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? Department { get; set; } = string.Empty;
    public string? Division { get; set; }
}
