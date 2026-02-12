using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Entities;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsService
{
    Task<Treatment> FindOneAsync(FindOneServiceParams parameters);
    Task<IEnumerable<Treatment>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Treatment?> CreateAsync(
        CreateServiceParams parameters);
    Task CloneAsync(Guid id);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}
