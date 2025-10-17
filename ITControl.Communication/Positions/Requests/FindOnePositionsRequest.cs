using ITControl.Domain.Positions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Positions.Requests;

public record FindOnePositionsRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator FindOnePositionRepositoryParams(FindOnePositionsRequest request)
    {
        return new FindOnePositionRepositoryParams
        {
            Id = request.Id
        };
    }
}
