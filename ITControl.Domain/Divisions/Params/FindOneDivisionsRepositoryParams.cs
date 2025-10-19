using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record FindOneDivisionsRepositoryParams : IFindOneRepositoryParams
{
    public Guid Id { get; init; }
    public IncludesDivisionsParams? Includes { get; init; } = null;
    
    public void Deconstruct(out Guid id, out IncludesDivisionsParams? includes)
    {
        id = Id;
        includes = Includes;
    }
}
