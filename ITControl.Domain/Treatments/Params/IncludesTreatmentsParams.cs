using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Treatments.Params;

public record IncludesTreatmentsParams : IncludesParams
{
    public bool? Call { get; set; }
    public bool? User { get; set; }
}