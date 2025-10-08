namespace ITControl.Domain.Calls.Params;

public class FindOneCallsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeUser { get; set; } = null;
    public bool? IncludeEquipment { get; set; } = null;
    public bool? IncludeSystem { get; set; } = null;
}