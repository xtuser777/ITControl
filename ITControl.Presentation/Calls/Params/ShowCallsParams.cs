using ITControl.Application.Calls.Params;
using ITControl.Domain.Calls.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record ShowCallsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    [FromQuery]
    public bool? IncludeUser { get; set; } = true;
    [FromQuery]
    public bool? IncludeEquipment { get; set; } = true;
    [FromQuery]
    public bool? IncludeSystem { get; set; } = true;

    public static implicit operator FindOneCallsServiceParams(ShowCallsParams param)
        => new FindOneCallsServiceParams
        {
            Id = param.Id,
            Includes = new IncludesCallsParams()
            {
                User = param.IncludeUser,
                Equipment = param.IncludeEquipment,
                System = param.IncludeSystem
            }
        };
}