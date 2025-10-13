namespace ITControl.Domain.Pages.Params;

public class FindManyPagesRepositoryParams
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }

    public static implicit operator CountPagesRepositoryParams(FindManyPagesRepositoryParams @params) =>
        new ()
        {
            Name = @params.Name,
        };
}