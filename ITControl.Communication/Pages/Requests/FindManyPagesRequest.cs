using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Pages.Requests;

public record FindManyPagesRequest : PageableRequest
{
    public string? Name { get; set; }

    public static implicit operator FindManyPagesParams(
        FindManyPagesRequest request) => 
        new() 
        { 
            Name = request.Name, 
        };

    public static implicit operator CountPagesRepositoryParams(
        FindManyPagesRequest request) =>
        new()
        {
            Name = request.Name,
        };

    public static implicit operator PaginationParams(
        FindManyPagesRequest request) =>
        new() 
        { 
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
}