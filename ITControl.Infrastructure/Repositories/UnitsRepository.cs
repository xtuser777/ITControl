using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class UnitsRepository(ApplicationDbContext context) : IUnitsRepository
{
    public async Task<Unit?> FindOneAsync(Guid id)
    {
        return await context.Units.FindAsync(id);
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
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
        int? page = null, int? size = null)
    {
        var query = context.Units.AsNoTracking();
        query = BuildQuery(
            query: query,
            name: name,
            phone: phone,
            postalCode: postalCode,
            streetName: streetName,
            neighborhood: neighborhood,
            addressNumber: addressNumber);
        query = BuildOrderBy(
            query, 
            orderByName, 
            orderByPhone, 
            orderByPostalCode, 
            orderBystreetName, 
            orderByNeighborhood,
            orderByAddressNumber);
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Unit unit)
    {
        await context.Units.AddAsync(unit);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Unit unit)
    {
        context.Units.Update(unit);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Unit unit)
    {
        context.Units.Remove(unit);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? name = null, 
        string? phone = null, 
        string? postalCode = null,
        string? streetName = null, 
        string? neighborhood = null, 
        string? addressNumber = null)
    {
        var query = context.Units.AsNoTracking();
        query = BuildQuery(
            query: query,
            id: id,
            name: name,
            phone: phone,
            postalCode: postalCode,
            streetName: streetName,
            neighborhood: neighborhood,
            addressNumber: addressNumber);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? name = null, 
        string? phone = null, 
        string? postalCode = null,
        string? streetName = null, 
        string? neighborhood = null, 
        string? addressNumber = null)
    {
        var count = await CountAsync(
            id: id,
            name: name,
            phone: phone,
            postalCode: postalCode,
            streetName: streetName,
            neighborhood: neighborhood,
            addressNumber: addressNumber);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? name = null, 
        string? phone = null, 
        string? postalCode = null,
        string? streetName = null, 
        string? neighborhood = null, 
        string? addressNumber = null)
    {
        var query = context.Units.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(
            query: query,
            name: name,
            phone: phone,
            postalCode: postalCode,
            streetName: streetName,
            neighborhood: neighborhood,
            addressNumber: addressNumber);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Unit> BuildQuery(
        IQueryable<Unit> query,
        Guid? id = null,
        string? name = null,
        string? phone = null,
        string? postalCode = null,
        string? streetName = null,
        string? neighborhood = null,
        string? addressNumber = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (name != null) query = query.Where(x => x.Name.Contains(name)); 
        if (phone != null) query = query.Where(x => x.Phone.Contains(phone));
        if (postalCode != null) query = query.Where(x => x.PostalCode.Contains(postalCode));
        if (streetName != null) query = query.Where(x => x.StreetName.Contains(streetName));
        if (neighborhood != null) query = query.Where(x => x.Neighborhood.Contains(neighborhood));
        if (addressNumber != null) query = query.Where(x => x.AddressNumber.Contains(addressNumber));
        
        return query;
    }

    private IQueryable<Unit> BuildOrderBy(
        IQueryable<Unit> query,
        string? orderByName,
        string? orderByPhone,
        string? orderByPostalCode,
        string? orderByStreetName,
        string? orderByNeighborhood,
        string? orderByAddressNumber)
    {
        if (orderByName != null) query = query.OrderBy(x => x.Name);
        if (orderByPhone != null) query = query.OrderBy(x => x.Phone);
        if (orderByPostalCode != null) query = query.OrderBy(x => x.PostalCode);
        if (orderByStreetName != null) query = query.OrderBy(x => x.StreetName);
        if (orderByNeighborhood != null) query = query.OrderBy(x => x.Neighborhood);
        if (orderByAddressNumber != null) query = query.OrderBy(x => x.AddressNumber);
        
        return query;
    }
}