using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Supplies.Params;

public record OrderBySuppliesParams : OrderByParams
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Stock { get; set; }
}