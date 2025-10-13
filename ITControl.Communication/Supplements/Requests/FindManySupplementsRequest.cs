using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Supplements.Requests;

public record FindManySupplementsRequest : PageableRequest
{
    public string? Brand { get; set; } = null!;
    public string? Model { get; set; } = null!;
    public string? Type { get; set; } = null!;
    public int? Stock { get; set; }
    public string? OrderByBrand { get; set; } = null!;
    public string? OrderByModel { get; set; } = null!;
    public string? OrderByType { get; set; } = null!;
    public string? OrderByStock { get; set; } = null!;
}
