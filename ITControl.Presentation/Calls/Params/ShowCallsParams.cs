using ITControl.Application.Shared.Params;
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

    public static implicit operator FindOneServiceParams(
        ShowCallsParams param)
        => new ()
        {
            Id = param.Id,
            Includes = new IncludesCallsParams()
            {
                User = new ()
                {
                    Unit = param.IncludeUser,
                    Position = param.IncludeUser,
                    Department = param.IncludeUser,
                    Division = param.IncludeUser,
                },
                Equipment = param.IncludeEquipment,
                System = param.IncludeSystem
            }
        };
}