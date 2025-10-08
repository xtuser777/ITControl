namespace ITControl.Domain.Treatments.Params;

public class FindOneTreatmentsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeCall { get; set; } = null;
    public bool? IncludeUser { get; set; } = null;
}
