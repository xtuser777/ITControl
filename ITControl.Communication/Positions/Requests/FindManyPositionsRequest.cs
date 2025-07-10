namespace ITControl.Communication.Positions.Requests;

public class FindManyPositionsRequest
{
    public string? Description { get; set; }
    public string? OrderByDescription { get; set; }
    public string? Page { get; set; }
    public string? Size { get; set; }
}