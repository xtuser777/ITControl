namespace ITControl.Domain.Contracts.Params;

public record FindManyContractsRepositoryParams
{
    public string? ObjectName { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountContractsRepositoryParams(FindManyContractsRepositoryParams @params)
    {
        return new CountContractsRepositoryParams
        {
            ObjectName = @params.ObjectName,
            StartedAt = @params.StartedAt,
            EndedAt = @params.EndedAt
        };
    }
}
