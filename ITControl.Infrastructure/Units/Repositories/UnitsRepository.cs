using ITControl.Domain.Units.Entities;
using ITControl.Domain.Units.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Units.Repositories;

public class UnitsRepository(ApplicationDbContext context) : IUnitsRepository
{
    public async Task<Unit?> FindOneAsync(Guid id)
    {
        return await context.Units.SingleOrDefaultAsync(x => x.Id == id);
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
    }

    public void Update(Unit unit)
    {
        context.Units.Update(unit);
    }

    public void Delete(Unit unit)
    {
        context.Units.Remove(unit);
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
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByPhone switch
        {
            "a" => query.OrderBy(p => p.Phone),
            "d" => query.OrderByDescending(p => p.Phone),
            _ => query
        };
        query = orderByPostalCode switch
        {
            "a" => query.OrderBy(p => p.PostalCode),
            "d" => query.OrderByDescending(p => p.PostalCode),
            _ => query
        };
        query = orderByStreetName switch
        {
            "a" => query.OrderBy(p => p.StreetName),
            "d" => query.OrderByDescending(p => p.StreetName),
            _ => query
        };
        query = orderByNeighborhood switch
        {
            "a" => query.OrderBy(p => p.Neighborhood),
            "d" => query.OrderByDescending(p => p.Neighborhood),
            _ => query
        };
        query = orderByAddressNumber switch
        {
            "a" => query.OrderBy(p => p.AddressNumber),
            "d" => query.OrderByDescending(p => p.AddressNumber),
            _ => query
        };
        
        return query;
    }
}