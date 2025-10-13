using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Positions.Params;

namespace ITControl.Communication.Positions.Requests;

public class FindManyPositionsRequest : PageableRequest
{
    public string? Description { get; set; }
    public string? OrderByDescription { get; set; }
    
    public static implicit operator FindManyPositionsRepositoryParams(FindManyPositionsRequest request) =>
        new()
        {
            Description = request.Description, 
            OrderByDescription = request.OrderByDescription,
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
    
    public static implicit operator CountPositionsRepositoryParams(FindManyPositionsRequest request) =>
        new()
        {
            Description = request.Description
        };
}