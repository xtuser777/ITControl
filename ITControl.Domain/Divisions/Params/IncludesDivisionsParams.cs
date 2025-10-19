namespace ITControl.Domain.Divisions.Params;

public record IncludesDivisionsParams
{
    public bool? Department { get; set; } = null;
}