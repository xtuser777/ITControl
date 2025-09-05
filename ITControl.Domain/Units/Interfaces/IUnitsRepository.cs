using ITControl.Domain.Units.Entities;

namespace ITControl.Domain.Units.Interfaces;

public interface IUnitsRepository
{
    Task<Unit?> FindOneAsync(Guid id);
    Task<IEnumerable<Unit>> FindManyAsync(
        string? name = null,
        string? phone = null,
        string? postalCode = null,
        string? streetName = null,
        string? neighborhood = null,
        string? addressNumber = null,
        string? orderByName = null,
        string? orderByPhone = null,
        string? orderByPostalCode = null,
        string? orderBystreetName = null,
        string? orderByNeighborhood = null,
        string? orderByAddressNumber = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Unit unit);
    void Update(Unit unit);
    void Delete(Unit unit);
    Task<int> CountAsync(
        Guid? id = null,
        string? name = null,
        string? phone = null,
        string? postalCode = null,
        string? streetName = null,
        string? neighborhood = null,
        string? addressNumber = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? name = null,
        string? phone = null,
        string? postalCode = null,
        string? streetName = null,
        string? neighborhood = null,
        string? addressNumber = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? name = null,
        string? phone = null,
        string? postalCode = null,
        string? streetName = null,
        string? neighborhood = null,
        string? addressNumber = null);
}