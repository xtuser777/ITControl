using ITControl.Domain.Equipments.Params;

namespace ITControl.Communication.Equipments.Requests;

public record FindOneEquipmentsRequest
{
    public Guid Id { get; set; }
    public bool? IncludeContract { get; set; } = true;

    public static implicit operator FindOneEquipmentsRepositoryParams(FindOneEquipmentsRequest request)
        => new()
        {
            Id = request.Id,
            IncludeContract = request.IncludeContract
        };
}
