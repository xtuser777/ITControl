using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;

namespace ITControl.Application.Equipments.Interfaces;

public interface IEquipmentsService
{
    Task<Equipment> FindOneAsync(FindOneEquipmentsRequest request);
    Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsRequest request, OrderByEquipmentsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyEquipmentsRequest request);
    Task<Equipment?> CreateAsync(CreateEquipmentsRequest request);
    Task UpdateAsync(Guid id, UpdateEquipmentsRequest request);
    Task DeleteAsync(Guid id);
}