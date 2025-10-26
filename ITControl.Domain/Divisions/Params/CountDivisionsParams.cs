namespace ITControl.Domain.Divisions.Params;

public record CountDivisionsParams : 
    FindManyDivisionsParams
{
    public Guid? Id { get; set; }
}
