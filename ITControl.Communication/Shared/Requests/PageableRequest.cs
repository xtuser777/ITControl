namespace ITControl.Communication.Shared.Requests;

public abstract record PageableRequest
{
    public string? Page { get; set; }
    public string? Size { get; set; }
}