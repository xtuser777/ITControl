using ITControl.Application.Shared.Params;
using ITControl.Presentation.Supplies.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Params;

public record CreateSuppliesParams
{
    [FromBody]
    public CreateSuppliesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateSuppliesParams param)
        => new()
        {
            Props = param.Request
        };
}