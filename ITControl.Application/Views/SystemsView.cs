using ITControl.Application.Interfaces;
using ITControl.Communication.Systems.Responses;

namespace ITControl.Application.Views;

public class SystemsView : ISystemsView
{
    public CreateSystemsResponse? Create(Domain.Entities.System? system)
    {
        if (system == null) return null;

        return new CreateSystemsResponse()
        {
            Id = system.Id.ToString(),
        };
    }

    public FindOneSystemsResponse? FindOne(Domain.Entities.System? system)
    {
        if (system == null) return null;

        return new FindOneSystemsResponse()
        {
            Id = system.Id.ToString(),
            Name = system.Name,
            Version = system.Version,
            ImplementedAt = system.ImplementedAt.ToString(),
            EndedAt = system.EndedAt.ToString(),
            Own = system.Own,
            ContractId = system.ContractId != null ? system.ContractId.ToString() : null,
            Contract = system.Contract != null ? new FindOneSystemsContractResponse()
            {
                Id = system.Contract.Id.ToString(),
                ObjectName = system.Contract.ObjectName,
            } : null,
        };
    }

    public IEnumerable<FindManySystemsResponse> FindMany(IEnumerable<Domain.Entities.System>? systems)
    {
        if (systems == null) return [];

        return from system in systems select new FindManySystemsResponse()
        {
            Id = system.Id.ToString(),
            Name = system.Name,
            Version = system.Version,
            ImplementedAt = system.ImplementedAt.ToString(),
            EndedAt = system.EndedAt.ToString(),
            Own = system.Own,
            ContractId = system.ContractId?.ToString(),
        };
    }
}