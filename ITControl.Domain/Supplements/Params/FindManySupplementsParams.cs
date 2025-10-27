using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record FindManySupplementsParams : FindManyParams
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public SupplementType? Type { get; set; }
    public int? Stock { get; set; }
}