using ITControl.Domain.Divisions.Params;

namespace ITControl.Application.Divisions.Params;

public record CreateDivisionsServiceParams
{
    public DivisionParams Params { get; set; } = null!;
}