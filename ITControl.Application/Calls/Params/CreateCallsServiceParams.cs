using ITControl.Domain.Calls.Params;

namespace ITControl.Application.Calls.Params;

public record CreateCallsServiceParams
{
    public CallParams Params { get; set; } = new();
}