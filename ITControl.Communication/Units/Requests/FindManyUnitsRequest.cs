using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Units.Requests;

public record FindManyUnitsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }
}