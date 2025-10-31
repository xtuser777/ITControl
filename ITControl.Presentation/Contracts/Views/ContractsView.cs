using ITControl.Domain.Contracts.Entities;
using ITControl.Presentation.Contracts.Interfaces;
using ITControl.Presentation.Contracts.Responses;

namespace ITControl.Presentation.Contracts.Views;

public class ContractsView : IContractsView
{
    public CreateContractsResponse? Create(Contract? contract)
    {
        if (contract is null) return null;

        return new CreateContractsResponse()
        {
            Id = contract.Id,
        };
    }

    public FindOneContractsResponse? FindOne(Contract? contract)
    {
        if (contract is null) return null;

        return new FindOneContractsResponse()
        {
            Id = contract.Id,
            Enterprise = contract.Enterprise,
            ObjectName = contract.ObjectName,
            StartedAt = contract.StartedAt,
            EndedAt = contract.EndedAt,
            ContractsContacts = contract.ContractContacts != null ? 
                from contact in contract.ContractContacts select 
                new FindOneContractsContactsResponse()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Cellphone = contact.Cellphone,
                }: []
        };
    }

    public IEnumerable<FindManyContractsResponse> FindMany(IEnumerable<Contract>? contracts)
    {
        if (contracts is null) return [];

        return from contract in contracts select new FindManyContractsResponse()
        {
            Id = contract.Id,
            Enterprise = contract.Enterprise,
            ObjectName = contract.ObjectName,
            StartedAt = contract.StartedAt,
            EndedAt = contract.EndedAt,
        };
    }
}