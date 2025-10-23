using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Treatments.Entities;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsService
{
    Task<Treatment> FindOneAsync(FindOneServiceParams parameters);
    Task<IEnumerable<Treatment>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Treatment?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}
