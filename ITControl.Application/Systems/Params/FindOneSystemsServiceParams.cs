using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Params;

public record FindOneSystemsServiceParams
{
    public Guid Id { get; set; }
    public IncludesSystemsParams? Includes { get; set; }

    public static implicit operator FindOneSystemsRepositoryParams(
        FindOneSystemsServiceParams param)
        => new()
        {
            Id = param.Id,
            Includes = param.Includes,
        };
}