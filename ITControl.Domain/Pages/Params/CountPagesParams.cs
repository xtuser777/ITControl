namespace ITControl.Domain.Pages.Params;

public record CountPagesParams : 
    FindManyPagesParams
{
    public Guid? Id { get; set; }
}