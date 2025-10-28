using ITControl.Domain.Contracts.Entities;
using ITControl.Presentation.Contracts.Responses;

namespace ITControl.Presentation.Contracts.Interfaces;

public interface IContractsView
{
    CreateContractsResponse? Create(Contract? contract);
    FindOneContractsResponse? FindOne(Contract? contract);
    IEnumerable<FindManyContractsResponse> 
        FindMany(IEnumerable<Contract>? contracts);
}