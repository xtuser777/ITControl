using ITControl.Domain.Enums;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Equipments.Repositories;

public class EquipmentsRepository(ApplicationDbContext context) : IEquipmentsRepository
{
    public async Task<Equipment?> FindOneAsync(
        Guid id, bool? includeContract)
    {
        var query = context.Equipments.AsQueryable();
        if (includeContract.HasValue) query = query.Include(x => x.Contract);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
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
        int? page = null, int? size = null)
    {
        var query = context.Equipments.AsNoTracking();
        query = BuildWhere(query, null, name, description, ip, mac, tag, rented, type);
        query = BuildOrderBy(
            query, 
            orderByName, 
            orderByDescription, 
            orderByIp, 
            orderByMac, 
            orderByTag, 
            orderByRented, 
            orderByType);
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Equipment equipment)
    {
        await context.Equipments.AddAsync(equipment);
    }

    public void Update(Equipment equipment)
    {
        context.Equipments.Update(equipment);
    }

    public void Delete(Equipment equipment)
    {
        context.Equipments.Remove(equipment);
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? name = null, 
        string? description = null, 
        string? ip = null, 
        string? mac = null,
        string? tag = null, 
        bool? rented = null, 
        EquipmentType? type = null)
    {
        var query = context.Equipments.AsNoTracking();
        query = BuildWhere(query, id, name, description, ip, mac, tag, rented, type);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? name = null,
        string? description = null, 
        string? ip = null,
        string? mac = null, 
        string? tag = null, 
        bool? rented = null, 
        EquipmentType? type = null)
    {
        var count = await CountAsync(id, name, description, ip, mac, tag, rented, type);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? ip = null, string? mac = null, string? tag = null)
    {
        var query = context.Equipments.AsNoTracking();
        query = BuildWhere(query: query, id: id, ip: ip, mac: mac, tag: tag);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Equipment> BuildWhere(
        IQueryable<Equipment> query,
        Guid? id = null,
        string? name = null,
        string? description = null,
        string? ip = null,
        string? mac = null,
        string? tag = null,
        bool? rented = null,
        EquipmentType? type = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (name != null) query = query.Where(x => x.Name.Contains(name));
        if (description != null) query = query.Where(x => x.Description.Contains(description));
        if (ip != null) query = query.Where(x => x.Ip.Contains(ip));
        if (mac != null) query = query.Where(x => x.Mac.Contains(mac));
        if (tag != null) query = query.Where(x => x.Tag.Contains(tag));
        if (rented != null) query = query.Where(x => x.Rented == rented);
        if (type != null) query = query.Where(x => x.Type == type);
        
        return query;
    }

    private IQueryable<Equipment> BuildOrderBy(
        IQueryable<Equipment> query,
        string? orderByName = null,
        string? orderByDescription = null,
        string? orderByIp = null,
        string? orderByMac = null,
        string? orderByTag = null,
        string? orderByRented = null,
        string? orderByType = null)
    {
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByDescription switch
        {
            "a" => query.OrderBy(p => p.Description),
            "d" => query.OrderByDescending(p => p.Description),
            _ => query
        };
        query = orderByIp switch
        {
            "a" => query.OrderBy(p => p.Ip),
            "d" => query.OrderByDescending(p => p.Ip),
            _ => query
        };
        query = orderByMac switch
        {
            "a" => query.OrderBy(p => p.Mac),
            "d" => query.OrderByDescending(p => p.Mac),
            _ => query
        };
        query = orderByTag switch
        {
            "a" => query.OrderBy(p => p.Tag),
            "d" => query.OrderByDescending(p => p.Tag),
            _ => query
        };
        query = orderByType switch
        {
            "a" => query.OrderBy(p => p.Type),
            "d" => query.OrderByDescending(p => p.Type),
            _ => query
        };
        query = orderByRented switch
        {
            "a" => query.OrderBy(p => p.Rented),
            "d" => query.OrderByDescending(p => p.Rented),
            _ => query
        };
        
        return query;
    }
}