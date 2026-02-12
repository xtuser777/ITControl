using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Supplies.Enums;
using ITControl.Domain.Supplies.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Params;

public record IndexSuppliesParams : PaginationParams
{
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public string? Type { get; init; }
    public int? Stock { get; init; }
    
    [FromHeader(Name = "X-Order-By-Brand")]
    public string? OrderByBrand { get; init; }
    
    [FromHeader(Name = "X-Order-By-Model")]
    public string? OrderByModel { get; init; }
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? OrderByType { get; init; }
    
    [FromHeader(Name = "X-Order-By-Stock")]
    public string? OrderByStock { get; init; }

    public static implicit operator OrderBySuppliesParams(
        IndexSuppliesParams request)
        => new()
        {
            Brand = request.OrderByBrand,
            Model = request.OrderByModel,
            Type = request.OrderByType,
            Stock = request.OrderByStock,
        };

    public static implicit operator FindManySuppliesParams(
        IndexSuppliesParams request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplyType>(request.Type),
            QuantityInStock = request.Stock
        };

    public static implicit operator CountSuppliesParams(
        IndexSuppliesParams request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplyType>(request.Type),
            QuantityInStock = request.Stock
        };

    public static implicit operator FindManyServiceParams(
        IndexSuppliesParams @params)
        => new()
        {
            FindManyProps = @params,
            OrderByParams = @params,
            PaginationParams = @params,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexSuppliesParams @params)
        => new()
        {
            CountProps = @params,
            PaginationParams = @params,
        };
}