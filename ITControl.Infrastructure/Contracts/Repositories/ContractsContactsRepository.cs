using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Contracts.Repositories;

public class ContractsContactsRepository(ApplicationDbContext context) : IContractsContactsRepository
{
    public async Task<IEnumerable<ContractContact>> FindManyByContractIdAsync(Guid contractId)
    {
        var contacts = await context.ContractContacts
            .Where(x => x.ContractId == contractId)
            .ToListAsync();
        
        return contacts;
    }

    public async Task CreateManyAsync(IEnumerable<ContractContact> contractContacts)
    {
        await context.ContractContacts.AddRangeAsync(contractContacts);
    }

    public async Task DeleteManyByContractAsync(Contract contract)
    {
        var ccs = await
            context.ContractContacts
                .AsQueryable()
                .Where(x => x.ContractId == (contract.Id ?? Guid.Empty))
                .ExecuteDeleteAsync();
    }
}