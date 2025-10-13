namespace ITControl.Domain.Positions.Params;

public class ExclusivePositionsRepositoryParams
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? Description { get; set; } = null;
}