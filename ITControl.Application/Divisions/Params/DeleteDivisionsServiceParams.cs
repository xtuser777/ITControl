namespace ITControl.Application.Divisions.Params;

public record DeleteDivisionsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneDivisionsServiceParams(DeleteDivisionsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}