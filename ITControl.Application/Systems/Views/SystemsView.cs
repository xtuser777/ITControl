using ITControl.Application.Systems.Interfaces;
using ITControl.Communication.Systems.Responses;

namespace ITControl.Application.Systems.Views;

public class SystemsView : ISystemsView
{
    public CreateSystemsResponse? Create(Domain.Systems.Entities.System? system)
    {
        if (system == null) return null;

        return new CreateSystemsResponse()
        {
            Id = system.Id,
        };
    }

    public FindOneSystemsResponse? FindOne(Domain.Systems.Entities.System? system)
    {
        if (system == null) return null;

        return new FindOneSystemsResponse()
        {
            Id = system.Id,
            Name = system.Name,
            Version = system.Version,
            ImplementedAt = system.ImplementedAt,
            EndedAt = system.EndedAt,
            Own = system.Own,
            ContractId = system.ContractId != null ? system.ContractId : null,
            Contract = system.Contract != null ? new FindOneSystemsContractResponse()
            {
                Id = system.Contract.Id,
                ObjectName = system.Contract.ObjectName,
            } : null,
        };
    }

    public IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Systems.Entities.System>? systems)
    {
        if (systems == null) return [];

        return from system in systems select new FindManySystemsResponse()
        {
            Id = system.Id,
            Name = system.Name,
            Version = system.Version,
            ImplementedAt = system.ImplementedAt,
            EndedAt = system.EndedAt,
            Own = system.Own,
            ContractId = system.ContractId,
        };
    }
}