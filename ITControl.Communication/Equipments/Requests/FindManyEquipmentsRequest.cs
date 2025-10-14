using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Equipments.Requests;

public record FindManyEquipmentsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Ip { get; set; }
    public string? Mac { get; set; }
    public string? Tag { get; set; }
    public string? Type { get; set; }
    public string? Rented { get; set; }

    public static implicit operator FindManyEquipmentsRepositoryParams(FindManyEquipmentsRequest request) =>
        new()
        {
            Name = request.Name,
            Description = request.Description,
            Ip = request.Ip,
            Mac = request.Mac,
            Tag = request.Tag,
            Type = Parser.ToEnumOptional<EquipmentType>(request.Type),
            Rented = Parser.ToBoolOptional(request.Rented)
        };

    public static implicit operator CountEquipmentsRepositoryParams(FindManyEquipmentsRequest request) =>
        new()
        {
            Name = request.Name,
            Description = request.Description,
            Ip = request.Ip,
            Mac = request.Mac,
            Tag = request.Tag,
            Type = Parser.ToEnumOptional<EquipmentType>(request.Type),
            Rented = Parser.ToBoolOptional(request.Rented)
        };

    public static implicit operator PaginationParams(FindManyEquipmentsRequest request) =>
        new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
}