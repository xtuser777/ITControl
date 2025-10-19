using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Equipments.Params;

public record FindOneEquipmentsServiceParams
{
    public Guid Id { get; set; }
    public IncludesEquipmentsParams? Includes { get; set; } = null;

    public static implicit operator FindOneRepositoryParams(FindOneEquipmentsServiceParams param)
        => new FindOneEquipmentsRepositoryParams
        {
            Id = param.Id,
            Includes = param.Includes,
        };
}