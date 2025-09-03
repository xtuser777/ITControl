using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class ContractContact : Entity
{
    public ContractContact(
        string name, string email, string phone, string cellphone, Guid contractId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        Cellphone = cellphone;
        ContractId = contractId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cellphone { get; set; }
    public Guid ContractId { get; set; }
    
    public void Update(
        string? name = null, string? email = null, 
        string? phone = null, string? cellphone = null)
    {
        Name = name ?? Name;
        Email = email ?? Email;
        Phone = phone ?? Phone;
        Cellphone = cellphone ?? Cellphone;
        UpdatedAt = DateTime.Now;
    }

    public Contract? Contract { get; set; }
}