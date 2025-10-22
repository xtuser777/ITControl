using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Params;

namespace ITControl.Communication.Supplements.Requests;

public record FindManySupplementsRequest : PageableRequest
{
    public string? Brand { get; set; } = null!;
    public string? Model { get; set; } = null!;
    public string? Type { get; set; } = null!;
    public int? Stock { get; set; }

    public static implicit operator FindManySupplementsParams(
        FindManySupplementsRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplementType>(request.Type),
            Stock = request.Stock
        };

    public static implicit operator CountSupplementsRepositoryParams(
        FindManySupplementsRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplementType>(request.Type),
            Stock = request.Stock
        };

    public static implicit operator PaginationParams(
        FindManySupplementsRequest request)
        => new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}
