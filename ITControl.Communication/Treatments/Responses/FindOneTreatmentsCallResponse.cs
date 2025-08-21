namespace ITControl.Communication.Treatments.Responses;

public class FindOneTreatmentsCallResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public FindOneTreatmentsCallLocationResponse Location { get; set; } = null!;
}
