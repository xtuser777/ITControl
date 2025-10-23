namespace ITControl.Domain.Treatments.Params;

public record ExclusiveTreatmentsParams : 
    FindManyTreatmentsParams
{
    public Guid ExcludeId { get; set; }
}
