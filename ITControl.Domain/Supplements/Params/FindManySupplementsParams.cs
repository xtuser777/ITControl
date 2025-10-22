using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record FindManySupplementsParams : FindManyParams
{
    public string? Brand { get; set; } = null;
    public string? Model { get; set; } = null;
    public SupplementType? Type { get; set; } = null;
    public int? Stock { get; set; } = null;
}