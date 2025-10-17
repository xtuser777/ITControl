using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Positions.Requests;

public record FindManyPositionsRequest : PageableRequest
{
    public string? Name { get; set; } = null;

    public static implicit operator FindManyPositionsRepositoryParams(FindManyPositionsRequest request) =>
        new()
        {
            Name = request.Name, 
        };
    
    public static implicit operator CountPositionsRepositoryParams(FindManyPositionsRequest request) =>
        new()
        {
            Name = request.Name
        };

    public static implicit operator PaginationParams(FindManyPositionsRequest request) =>
        new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
}