using ITControl.Domain.Divisions.Params;

namespace ITControl.Application.Divisions.Params;

public record FindOneDivisionsServiceParams
{
    public Guid Id { get; set; }
    public IncludesDivisionsParams? Includes { get; set; } = null;

    public static implicit operator FindOneDivisionsRepositoryParams(FindOneDivisionsServiceParams @params)
        => new()
        {
            Id = @params.Id,
            Includes = @params.Includes,
        };
}