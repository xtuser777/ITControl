using ITControl.Domain.Calls.Params;

namespace ITControl.Application.Calls.Params;

public record FindOneCallsServiceParams
{
    public Guid Id { get; set; }
    public IncludesCallsParams? Includes { get; set; } = new();

    public static implicit operator FindOneCallsRepositoryParams(FindOneCallsServiceParams param)
        => new ()
        {
            Id = param.Id,
            Includes = param.Includes,
        };
}