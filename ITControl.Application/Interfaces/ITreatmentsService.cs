using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface ITreatmentsService
{
    Task<Treatment> FindOneAsync(
        Guid id,
        bool? includeCall = null,
        bool? includeUser = null);
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
