using ITControl.Application.Divisions.Params;
using ITControl.Domain.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record ShowDivisionsControllerParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
    
    [FromQuery]
    public bool? IncludeDepartment { get; set; } = true;

    public static implicit operator FindOneDivisionsServiceParams(ShowDivisionsControllerParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesDivisionsParams
            {
                Department = param.IncludeDepartment
            }
        };
}