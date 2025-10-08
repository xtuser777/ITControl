namespace ITControl.Domain.Treatments.Params;

public class BuildOrderByTreatmentsRepositoryParams
{
    public IQueryable<Entities.Treatment> Query { get; set; } = null!;
    public FindManyTreatmentsRepositoryParams Params { get; set; } = null!;
    public void Deconstruct(
        out IQueryable<Entities.Treatment> query,
        out FindManyTreatmentsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
