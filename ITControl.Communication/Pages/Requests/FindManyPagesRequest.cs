using ITControl.Communication.Shared.Requests;
using ITControl.Infrastructure.Pages.Repositories;

namespace ITControl.Communication.Pages.Requests;

public class FindManyPagesRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }

    public static implicit operator FindManyPagesRepositoryParams(FindManyPagesRequest request) => 
        new() 
        { 
            Name = request.Name, 
            OrderByName = request.OrderByName,
            Page = request.Page != null ? int.Parse(request.Page) : null,
            Size = request.Size != null ? int.Parse(request.Size) : null
        };

    public static implicit operator CountPagesRepositoryParams(FindManyPagesRequest request) =>
        new() 
        { 
            Name = request.Name 
        };
}