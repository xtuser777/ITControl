using ITControl.Application.Shared.Params;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record IndexEquipmentsParams : PaginationParams
{
    public string? Name { get; init; } = null;
    public string? Description { get; init; } = null;
    public string? Ip { get; init; } = null;
    public string? Mac { get; init; } = null;
    public string? Tag { get; init; } = null;
    public string? Type { get; init; } = null;
    public string? Rented { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Ip")]
    public string? OrderByIp { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Mac")]
    public string? OrderByMac { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Tag")]
    public string? OrderByTag { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? OrderByType { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Rented")]
    public string? OrderByRented { get; init; } = null;

    public static implicit operator OrderByEquipmentsParams(
        IndexEquipmentsParams request) =>
        new()
        {
            Name = request.OrderByName,
            Description = request.OrderByDescription,
            Ip = request.OrderByIp,
            Mac = request.OrderByMac,
            Tag = request.OrderByTag,
            Type = request.OrderByType,
            Rented = request.OrderByRented
        };

    public static implicit operator FindManyEquipmentsParams(
        IndexEquipmentsParams request) =>
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

    public static implicit operator CountEquipmentsParams(
        IndexEquipmentsParams request)
        => new()
        {
            Name = request.Name,
            Description = request.Description,
            Ip = request.Ip,
        };

    public static implicit operator FindManyServiceParams(
        IndexEquipmentsParams parameters)
    {
        var serviceParams = new FindManyServiceParams()
        {
            FindManyProps = parameters,
            OrderByParams = parameters,
            PaginationParams = parameters,
        };
        
        return serviceParams;
    }

    public static implicit operator FindManyPaginationServiceParams(
        IndexEquipmentsParams parameters)
        => new()
        {
            CountProps= parameters,
            PaginationParams = parameters,
        };
}