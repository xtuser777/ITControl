using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Contracts.Props;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Entities;

public sealed class ContractContact : ContractContactProps
{
    public ContractContact()
    {
    }

    public ContractContact(Guid? contractId, ContractContactProps @params)
    {
        Assign(@params);
        ContractId = contractId;
    }
    
    public void Update(ContractContactProps @params)
    {
        AssignUpdate(@params);
    }
}