using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record IncludesEquipmentsParams : IncludesParams
{
    public bool? Contract { get; set; } = null;
}