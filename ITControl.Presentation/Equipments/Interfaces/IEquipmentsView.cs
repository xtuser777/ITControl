using ITControl.Domain.Equipments.Entities;
using ITControl.Presentation.Equipments.Responses;

namespace ITControl.Presentation.Equipments.Interfaces;

public interface IEquipmentsView
{
    CreateEquipmentsResponse? Create(Equipment? equipment);
    FindOneEquipmentsResponse? FindOne(Equipment? equipment);
    IEnumerable<FindManyEquipmentsResponse> FindMany(IEnumerable<Equipment>? equipments);
}