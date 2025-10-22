using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Params;

public record CreateSupplementsServiceParams
{
    public SupplementParams Params { get; set; } = new();
}