namespace ITControl.Domain.Divisions.Params;

public class FindOneDivisionsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeDepartment { get; set; }
    
    public void Deconstruct(out Guid id, out bool? includeDepartment)
    {
        id = Id;
        includeDepartment = IncludeDepartment;
    }
}
