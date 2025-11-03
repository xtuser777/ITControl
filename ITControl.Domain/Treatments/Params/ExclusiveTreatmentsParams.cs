namespace ITControl.Domain.Treatments.Params;

public class ExclusiveTreatmentsParams : 
    FindManyTreatmentsParams
{
    public Guid ExcludeId { get; set; }
}
