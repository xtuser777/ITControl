using ITControl.Application.Interfaces;
using ITControl.Communication.Contracts.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

public class ContractsView : IContractsView
{
    public CreateContractsResponse? Create(Contract? contract)
    {
        if (contract is null) return null;

        return new CreateContractsResponse()
        {
            Id = contract.Id.ToString(),
        };
    }

    public FindOneContractsResponse? FindOne(Contract? contract)
    {
        if (contract is null) return null;

        return new FindOneContractsResponse()
        {
            Id = contract.Id.ToString(),
            Object = contract.Object,
            StartedAt = contract.StartedAt.ToString(),
            EndedAt = contract.EndedAt.ToString(),
            ContractsContacts = contract.ContractContacts != null ? 
                from contact in contract.ContractContacts select 
                new FindOneContractsContactsResponse()
                {
                    Id = contact.Id.ToString(),
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
            Id = contract.Id.ToString(),
            Object = contract.Object,
            StartedAt = contract.StartedAt.ToString(),
            EndedAt = contract.EndedAt.ToString(),
        };
    }
}