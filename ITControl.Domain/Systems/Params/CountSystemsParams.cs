namespace ITControl.Domain.Systems.Params;

public record CountSystemsParams : FindManySystemsParams
{
    public Guid? Id { get; set; }
}
