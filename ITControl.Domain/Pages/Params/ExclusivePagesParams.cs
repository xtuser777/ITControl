namespace ITControl.Domain.Pages.Params;

public record ExclusivePagesParams : 
    FindManyPagesParams
{
    public Guid ExcludeId { get; set; }
}