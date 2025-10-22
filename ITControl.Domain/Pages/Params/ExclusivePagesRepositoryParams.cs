namespace ITControl.Domain.Pages.Params;

public record ExclusivePagesRepositoryParams : 
    FindManyPagesParams
{
    public Guid ExcludeId { get; set; }
}