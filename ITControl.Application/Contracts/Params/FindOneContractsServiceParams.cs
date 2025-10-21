using ITControl.Domain.Contracts.Params;

namespace ITControl.Application.Contracts.Params;

public record FindOneContractsServiceParams
{
    public Guid Id { get; set; }
    public IncludesContractsParams Includes { get; set; } = new();

    public static implicit operator FindOneContractsRepositoryParams(
        FindOneContractsServiceParams serviceParams)
        => new()
        {
            Id = serviceParams.Id,
            Includes = serviceParams.Includes,
        };
}
