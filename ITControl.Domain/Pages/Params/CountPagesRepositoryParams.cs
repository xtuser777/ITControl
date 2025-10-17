namespace ITControl.Domain.Pages.Params;

public record CountPagesRepositoryParams : FindManyPagesRepositoryParams
{
    public Guid? Id { get; set; } = null;
}