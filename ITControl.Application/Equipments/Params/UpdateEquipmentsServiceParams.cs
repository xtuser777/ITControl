using ITControl.Domain.Equipments.Params;

namespace ITControl.Application.Equipments.Params;

public record UpdateEquipmentsServiceParams
{
    public Guid Id { get; set; }
    public UpdateEquipmentParams Params { get; set; } = null!;
    
    public static implicit operator FindOneEquipmentsServiceParams(
        UpdateEquipmentsServiceParams @param) 
        => new() { Id = @param.Id };
}