using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Supplements.Params;

public record OrderBySupplementsParams : OrderByParams
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Stock { get; set; }
}