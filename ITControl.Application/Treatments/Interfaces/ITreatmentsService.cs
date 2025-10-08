using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Treatments.Entities;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsService
{
    Task<Treatment> FindOneAsync(FindOneTreatmentsRequest request);
    Task<IEnumerable<Treatment>> FindManyAsync(
        FindManyTreatmentsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyTreatmentsRequest request);
    Task<Treatment?> CreateAsync(
        CreateTreatmentsRequest request);
    Task UpdateAsync(
        Guid id, 
        UpdateTreatmentsRequest request);
    Task DeleteAsync(Guid id);
}
