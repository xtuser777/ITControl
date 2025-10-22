namespace ITControl.Domain.Pages.Params;

public record CountPagesRepositoryParams : 
    FindManyPagesParams
{
    public Guid? Id { get; set; } = null;
}