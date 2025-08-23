using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Pages.Requests;

public class FindManyPagesRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }
}