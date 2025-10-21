using ITControl.Domain.Divisions.Params;

namespace ITControl.Application.Divisions.Params;

public record UpdateDivisionsServiceParams
{
    public Guid Id { get; set; }
    public UpdateDivisionParams Params { get; set; } = null!;

    public static implicit operator FindOneDivisionsServiceParams(
        UpdateDivisionsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}