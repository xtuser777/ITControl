using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Equipments.Params;

public record IncludesEquipmentsParams : IncludesParams
{
    public bool? Contract { get; set; }
}