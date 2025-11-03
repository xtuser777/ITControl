using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Props;

public class ContractContactProps : Entity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public Guid? ContractId { get; set; }
    public Contract? Contract { get; set; }
}