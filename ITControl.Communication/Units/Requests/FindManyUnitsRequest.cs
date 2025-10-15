using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Units.Params;

namespace ITControl.Communication.Units.Requests;

public record FindManyUnitsRequest : PageableRequest
{
    public string? Name { get; set; }

    public static implicit operator FindManyUnitsRepositoryParams(FindManyUnitsRequest request) => new()
    {
        Name = request.Name
    };

    public static implicit operator CountUnitsRepositoryParams(FindManyUnitsRequest request) => new()
    {
        Name = request.Name
    };

    public static implicit operator PaginationParams(FindManyUnitsRequest request) => new()
    {
        Page = Parser.ToIntOptional(request.Page),
        Size = Parser.ToIntOptional(request.Size)
    };
}