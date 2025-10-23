using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Units.Params;

namespace ITControl.Communication.Units.Requests;

public record FindManyUnitsRequest : FindManyRequest
{
    public string? Name { get; set; }

    public static implicit operator FindManyUnitsParams(
        FindManyUnitsRequest request) => new()
    {
        Name = request.Name
    };

    public static implicit operator CountUnitsParams(
        FindManyUnitsRequest request) => new()
    {
        Name = request.Name
    };
}