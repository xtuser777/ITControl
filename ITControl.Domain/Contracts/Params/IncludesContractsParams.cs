using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Contracts.Params;

public record IncludesContractsParams : IncludesParams
{
    public bool? Contacts { get; set; } = null;
}
