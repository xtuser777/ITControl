using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Units.Params;

namespace ITControl.Communication.Units.Requests;

public record OrderByUnitsRequest
{
    public string? Name { get; set; }

    public static implicit operator OrderByUnitsRepositoryParams(OrderByUnitsRequest request) => new()
    {
        Name = request.Name
    };
}