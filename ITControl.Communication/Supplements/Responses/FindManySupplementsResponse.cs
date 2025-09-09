using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Supplements.Responses;

public class FindManySupplementsResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public TranslatableField Type { get; set; } = null!;
    public int Stock { get; set; }
}
