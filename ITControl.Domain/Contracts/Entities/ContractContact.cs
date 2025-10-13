using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Entities;

public sealed class ContractContact : Entity
{
    public ContractContact()
    {
    }

    public ContractContact(Guid contractId, ContractContactParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        Email = @params.Email;
        Phone = @params.Phone;
        Cellphone = @params.Cellphone;
        ContractId = contractId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
    public Guid ContractId { get; set; }
    
    public void Update(UpdateContractContactParams @params)
    {
        Name = @params.Name ?? Name;
        Email = @params.Email ?? Email;
        Phone = @params.Phone ?? Phone;
        Cellphone = @params.Cellphone ?? Cellphone;
        UpdatedAt = DateTime.Now;
    }

    public Contract? Contract { get; set; }
}