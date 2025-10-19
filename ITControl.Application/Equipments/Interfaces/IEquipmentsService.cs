using ITControl.Application.Equipments.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;

namespace ITControl.Application.Equipments.Interfaces;

public interface IEquipmentsService
{
    Task<Equipment> FindOneAsync(FindOneEquipmentsServiceParams @params);
    Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPaginationEquipmentsServiceParams @params);
    Task<Equipment?> CreateAsync(CreateEquipmentsServiceParams @params);
    Task UpdateAsync(UpdateEquipmentsServiceParams @params);
    Task DeleteAsync(DeleteEquipmentsServiceParams @params);
}