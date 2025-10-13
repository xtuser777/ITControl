namespace ITControl.Domain.Contracts.Params;

public record FindOneContractsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeContractsContacts { get; set; } = null;

    public void Deconstruct(out Guid id, out bool? includeContractsContacts)
    {
        id = Id;
        includeContractsContacts = IncludeContractsContacts;
    }
}
