using ITControl.Domain.Shared.Params2;

namespace ITControl.Application.Shared.Params;

public record FindOneServiceParams
{
    public Guid Id { get; set; }
    public IncludesParams? Includes { get; set; }

    public static implicit operator FindOneRepositoryParams(
        FindOneServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
            Includes = parameters.Includes
        };
}