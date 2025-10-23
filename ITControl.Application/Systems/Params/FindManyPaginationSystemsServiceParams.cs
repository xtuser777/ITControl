using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Params;

public record FindManyPaginationSystemsServiceParams
{
    public CountSystemsRepositoryParams 
        CountSystemsRepositoryParams { get; set; } = new();

    public string? Page { get; set; }
    public string? Size { get; set; }

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }
    
    public static implicit operator CountSystemsRepositoryParams(
        FindManyPaginationSystemsServiceParams parameters)
        => parameters.CountSystemsRepositoryParams;
}