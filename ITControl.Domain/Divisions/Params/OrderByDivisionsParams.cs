using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Divisions.Params;

public record OrderByDivisionsParams : OrderByParams
{
    public string? Name { get; set; } 
    public string? Department { get; set; } 
}
