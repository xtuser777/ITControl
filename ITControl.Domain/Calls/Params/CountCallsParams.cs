namespace ITControl.Domain.Calls.Params;

public record CountCallsParams : 
    FindManyCallsParams
{
    public Guid? Id { get; set; } = null;
}