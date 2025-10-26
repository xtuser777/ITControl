using ITControl.Application.Shared.Params;
using ITControl.Domain.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record ShowDivisionsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
    
    [FromQuery]
    public bool? IncludeDepartment { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowDivisionsParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesDivisionsParams
            {
                Department = param.IncludeDepartment
            }
        };
}