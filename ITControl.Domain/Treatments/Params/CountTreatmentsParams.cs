namespace ITControl.Domain.Treatments.Params;

public record CountTreatmentsParams : FindManyTreatmentsParams
{
    public Guid? Id { get; set; } = null;
}
