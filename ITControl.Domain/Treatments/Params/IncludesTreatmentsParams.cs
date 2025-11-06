using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Treatments.Params;

public record IncludesTreatmentsParams : IncludesParams
{
    public IncludesTreatmentsCallParams? Call { get; set; }
    public bool? User { get; set; }
}

public record IncludesTreatmentsCallParams
{
    public IncludesTreatmentsCallUserParams? User { get; set; }
}

    public record IncludesTreatmentsCallUserParams
{
    public bool? Unit { get; set; }
    public bool? Department { get; set; }
    public bool? Division { get; set; }
}