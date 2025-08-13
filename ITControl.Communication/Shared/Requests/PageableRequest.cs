namespace ITControl.Communication.Shared.Requests;

public abstract class PageableRequest
{
    public string? Page { get; set; }
    public string? Size { get; set; }
}