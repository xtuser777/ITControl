using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Supplies.Responses;

public class FindOneSuppliesResponse
{
    public Guid? Id { get; set; }
    public string? Brand { get; set; } = null!;
    public string? Model { get; set; } = null!;
    public TranslatableField? Type { get; set; } = null!;
    public int? Stock { get; set; }
}
