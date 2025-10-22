using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record OrderBySupplementsParams : OrderByParams
{
    public string? Brand { get; set; } = null;
    public string? Model { get; set; } = null;
    public string? Type { get; set; } = null;
    public string? Stock { get; set; } = null;
}