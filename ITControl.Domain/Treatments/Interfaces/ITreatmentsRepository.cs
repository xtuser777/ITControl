using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Params;

namespace ITControl.Domain.Treatments.Interfaces;

public interface ITreatmentsRepository
{
    Task<Treatment?> FindOneAsync(FindOneTreatmentsRepositoryParams @params);
    Task<IEnumerable<Treatment>> FindManyAsync(FindManyTreatmentsRepositoryParams @params);
    Task CreateAsync(Treatment treatment);
    void Update(Treatment treatment);
    void Delete(Treatment treatment);
    Task<int> CountAsync(CountTreatmentsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsTreatmentsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveTreatmentsRepositoryParams @params);
}