using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Contracts.Props;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Entities;

public sealed class Contract : ContractProps
{
    public Contract()
    {
    }

    public Contract(ContractProps @params)
    {
        Assign(@params);
    }

    public void Update(ContractProps @params)
    {
        AssignUpdate(@params);
    }
}