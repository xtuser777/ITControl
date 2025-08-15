using ITControl.Communication.Contracts.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IContractsView
{
    CreateContractsResponse? Create(Contract? contract);
    FindOneContractsResponse? FindOne(Contract? contract);
    IEnumerable<FindManyContractsResponse> FindMany(IEnumerable<Contract>? contracts);
}