using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IEquipmentsService
{
    Task<Equipment> FindOneAsync(
        Guid id, 
        bool? includeContract = null);
    Task<IEnumerable<Equipment>> FindManyAsync(FindManyEquipmentsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyEquipmentsRequest request);
    Task<Equipment?> CreateAsync(CreateEquipmentsRequest request);
    Task UpdateAsync(Guid id, UpdateEquipmentsRequest request);
    Task DeleteAsync(Guid id);
}