namespace ITControl.Domain.Systems.Params;

public record CountSystemsRepositoryParams : FindManySystemsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
