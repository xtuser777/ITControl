using ITControl.Domain.Contracts.Params;

namespace ITControl.Communication.Contracts.Requests;

public record FindOneContractsRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool? IncludeContractsContacts { get; set; } = null;

    public static implicit operator FindOneContractsRepositoryParams(FindOneContractsRequest request) =>
        new()
        {
            Id = request.Id,
            IncludeContractsContacts = request.IncludeContractsContacts
        };
}
