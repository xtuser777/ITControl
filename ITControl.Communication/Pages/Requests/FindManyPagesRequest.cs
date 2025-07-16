namespace ITControl.Communication.Pages.Requests;

public class FindManyPagesRequest
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }
    public string? Page { get; set; }
    public string? Size { get; set; }
}