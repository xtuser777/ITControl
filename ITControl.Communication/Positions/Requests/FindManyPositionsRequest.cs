using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Positions.Requests;

public class FindManyPositionsRequest : PageableRequest
{
    public string? Description { get; set; }
    public string? OrderByDescription { get; set; }
}