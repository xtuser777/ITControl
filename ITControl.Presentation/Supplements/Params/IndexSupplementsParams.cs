using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record IndexSupplementsParams : PaginationParams
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

    public static implicit operator OrderBySupplementsParams(
        IndexSupplementsParams request)
        => new()
        {
            Brand = request.OrderByBrand,
            Model = request.OrderByModel,
            Type = request.OrderByType,
            Stock = request.OrderByStock,
        };

    public static implicit operator FindManySupplementsParams(
        IndexSupplementsParams request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplementType>(request.Type),
            Stock = request.Stock
        };

    public static implicit operator CountSupplementsParams(
        IndexSupplementsParams request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplementType>(request.Type),
            Stock = request.Stock
        };

    public static implicit operator FindManyServiceParams(
        IndexSupplementsParams @params)
        => new()
        {
            FindManyParams = @params,
            OrderByParams = @params,
            PaginationParams = @params,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexSupplementsParams @params)
        => new()
        {
            CountParams = @params,
            PaginationParams = @params,
        };
}