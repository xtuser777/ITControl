namespace ITControl.Domain.Calls.Params;

public record CountCallsRepositoryParams : 
    FindManyCallsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}