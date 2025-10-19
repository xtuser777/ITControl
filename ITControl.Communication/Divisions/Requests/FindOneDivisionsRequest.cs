using ITControl.Domain.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Divisions.Requests;

public record FindOneDivisionsRequest
{
    [FromRoute]
    public Guid Id { get; init; } = Guid.Empty;
    
    [FromQuery]
    public bool? IncludeDepartment { get; init; } = true;

    public static implicit operator FindOneDivisionsRepositoryParams(FindOneDivisionsRequest request)
        => new()
        {
            Id = request.Id,
            Includes = new IncludesDivisionsParams
            {
                Department = request.IncludeDepartment,
            }
        };
}
