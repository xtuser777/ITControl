using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using System.Linq.Expressions;

namespace ITControl.Domain.Interfaces;

public interface IEquipmentsRepository
{
    Task<Equipment?> FindOneAsync(
        Expression<Func<Equipment?, bool>> predicate, bool? includeContract = false);
    Task<IEnumerable<Equipment>> FindManyAsync(
        string? name = null,
        string? description = null,
        string? ip = null,
        string? mac = null,
        string? tag = null,
        bool? rented = null,
        EquipmentType? type = null,
        string? orderByName = null,
        string? orderByDescription = null,
        string? orderByIp = null,
        string? orderByMac = null,
        string? orderByTag = null,
        string? orderByRented = null,
        string? orderByType = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Equipment equipment);
    void Update(Equipment equipment);
    void Delete(Equipment equipment);
    Task<int> CountAsync(
        Guid? id = null,
        string? name = null,
        string? description = null,
        string? ip = null,
        string? mac = null,
        string? tag = null,
        bool? rented = null,
        EquipmentType? type = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? name = null,
        string? description = null,
        string? ip = null,
        string? mac = null,
        string? tag = null,
        bool? rented = null,
        EquipmentType? type = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? ip = null,
        string? mac = null,
        string? tag = null);
}