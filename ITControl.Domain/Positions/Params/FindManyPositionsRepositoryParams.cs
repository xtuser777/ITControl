namespace ITControl.Domain.Positions.Params;

public class FindManyPositionsRepositoryParams
{
    public string? Description { get; set; } = null;
    public string? OrderByDescription { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountPositionsRepositoryParams(FindManyPositionsRepositoryParams @params) =>
        new CountPositionsRepositoryParams()
        {
            Description = @params.Description,
        };
}