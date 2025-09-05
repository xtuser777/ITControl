using ITControl.Communication.Contracts.Responses;
using ITControl.Domain.Contracts.Entities;

namespace ITControl.Application.Contracts.Interfaces;

public interface IContractsView
{
    CreateContractsResponse? Create(Contract? contract);
    FindOneContractsResponse? FindOne(Contract? contract);
    IEnumerable<FindManyContractsResponse> FindMany(IEnumerable<Contract>? contracts);
}