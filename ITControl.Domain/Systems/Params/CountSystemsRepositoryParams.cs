namespace ITControl.Domain.Systems.Params;

public record CountSystemsRepositoryParams : FindManySystemsParams
{
    public Guid? Id { get; set; } = null;
}
