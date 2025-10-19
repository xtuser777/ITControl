namespace ITControl.Application.Equipments.Params;

public record DeleteEquipmentsServiceParams
{
    public Guid Id { get; init; }
    
    public static implicit operator FindOneEquipmentsServiceParams(
        DeleteEquipmentsServiceParams param) 
        => new() { Id = param.Id };
}