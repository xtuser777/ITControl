using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record IncludesContractsParams : IncludesParams
{
    public bool? ContractContacts { get; set; }
}
