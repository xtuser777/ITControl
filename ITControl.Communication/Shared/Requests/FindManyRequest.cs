using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Shared.Requests;

public record FindManyRequest : PageableRequest
{
    
    public static implicit operator PaginationParams(
        FindManyRequest request)
        => new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}