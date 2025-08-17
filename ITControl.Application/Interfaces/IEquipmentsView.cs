using ITControl.Communication.Equipments.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IEquipmentsView
{
    CreateEquipmentsResponse? Create(Equipment? equipment);
    FindOneEquipmentsResponse? FindOne(Equipment? equipment);
    IEnumerable<FindManyEquipmentsResponse> FindMany(IEnumerable<Equipment>? equipments);
}