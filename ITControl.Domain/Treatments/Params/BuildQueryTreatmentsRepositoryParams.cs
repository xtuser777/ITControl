namespace ITControl.Domain.Treatments.Params;

public class BuildQueryTreatmentsRepositoryParams
{
    public IQueryable<Entities.Treatment> Query { get; set; } = null!;
    public CountTreatmentsRepositoryParams Params { get; set; } = null!;
    public void Deconstruct(
        out IQueryable<Entities.Treatment> query,
        out CountTreatmentsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
