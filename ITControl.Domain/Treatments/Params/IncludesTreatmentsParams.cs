using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Treatments.Params;

public record IncludesTreatmentsParams : IncludesParams
{
    public bool? Call { get; set; }
    public bool? User { get; set; }
}