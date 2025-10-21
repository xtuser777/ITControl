namespace ITControl.Application.Contracts.Params;

public record DeleteContractsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneContractsServiceParams(
        DeleteContractsServiceParams model)
        => new() { Id = model.Id };
}
