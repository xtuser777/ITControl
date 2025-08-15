using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

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
        await context.SaveChangesAsync();
    }

    public async Task DeleteManyByContractAsync(Contract contract)
    {
        await context.ContractContacts.Where(x => x.ContractId == contract.Id).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }
}