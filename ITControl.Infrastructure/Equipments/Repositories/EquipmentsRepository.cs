using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Equipments.Repositories;

public class EquipmentsRepository(ApplicationDbContext context) : IEquipmentsRepository
{
    private IQueryable<Equipment> query = null!;

    public async Task<Equipment?> FindOneAsync(FindOneEquipmentsRepositoryParams @params)
    {
        var (id, includeContract) = @params;
        var query = context.Equipments.AsQueryable();
        if (includeContract.HasValue) query = query.Include(x => x.Contract);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsRepositoryParams findManyParams,
        OrderByEquipmentsRepositoryParams orderByParams,
        PaginationParams paginationParams)
    {
        var (page, size) = paginationParams;
        query = context.Equipments.AsNoTracking();
        BuildWhere((CountEquipmentsRepositoryParams)findManyParams);
        BuildOrderBy(orderByParams);
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

    public async Task<int> CountAsync(CountEquipmentsRepositoryParams @params)
    {
        query = context.Equipments.AsNoTracking();
        BuildWhere(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsEquipmentsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveEquipmentsRepositoryParams @params)
    {
        query = context.Equipments.AsNoTracking();
        BuildWhere(new CountEquipmentsRepositoryParams() { 
            Ip = @params.Ip, Mac = @params.Mac, Tag = @params.Tag});
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private void BuildWhere(CountEquipmentsRepositoryParams @params)
    {
        if (@params.Id != null) 
            query = query.Where(x => x.Id == @params.Id);
        if (@params.Name!= null) 
            query = query.Where(x => x.Name.Contains(@params.Name));
        if (@params.Description!= null) 
            query = query.Where(x => x.Description.Contains(@params.Description));
        if (@params.Ip!= null) 
            query = query.Where(x => x.Ip.Contains(@params.Ip));
        if (@params.Mac!= null) 
            query = query.Where(x => x.Mac.Contains(@params.Mac));
        if (@params.Tag!= null) 
            query = query.Where(x => x.Tag.Contains(@params.Tag));
        if (@params.Rented != null) 
            query = query.Where(x => x.Rented == @params.Rented );
        if (@params.Type != null) 
            query = query.Where(x => x.Type == @params.Type );
    }

    private void BuildOrderBy(OrderByEquipmentsRepositoryParams @params)
    {
        query = @params.Name switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = @params.Description switch
        {
            "a" => query.OrderBy(p => p.Description),
            "d" => query.OrderByDescending(p => p.Description),
            _ => query
        };
        query = @params.Ip switch
        {
            "a" => query.OrderBy(p => p.Ip),
            "d" => query.OrderByDescending(p => p.Ip),
            _ => query
        };
        query = @params.Mac switch
        {
            "a" => query.OrderBy(p => p.Mac),
            "d" => query.OrderByDescending(p => p.Mac),
            _ => query
        };
        query = @params.Tag switch
        {
            "a" => query.OrderBy(p => p.Tag),
            "d" => query.OrderByDescending(p => p.Tag),
            _ => query
        };
        query = @params.Type switch
        {
            "a" => query.OrderBy(p => p.Type),
            "d" => query.OrderByDescending(p => p.Type),
            _ => query
        };
        query = @params.Rented switch
        {
            "a" => query.OrderBy(p => p.Rented),
            "d" => query.OrderByDescending(p => p.Rented),
            _ => query
        };
    }
}