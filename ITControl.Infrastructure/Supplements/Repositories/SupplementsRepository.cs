using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Supplements.Repositories;

public class SupplementsRepository(
    ApplicationDbContext context) : ISupplementsRepository
{
    public async Task<Supplement?> FindOneAsync(Guid id)
    {
        return await context.Supplements.FindAsync(id);
    }

    public async Task<IEnumerable<Supplement>> FindManyAsync(
        string? brand = null, string? model = null, SupplementType? type = null, int? stock = null, 
        string? orderByBrand = null, string? orderByModel = null, string? orderByType = null, string? orderByStock = null, 
        int? page = null, int? size = null)
    {
        var query = context.Supplements.AsNoTracking();
        query = ApplyFilters(query, null, brand, model, type, stock);
        query = ApplyOrdering(query, orderByBrand, orderByModel, orderByType, orderByStock);
        if (page is not null && size is not null)
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);

        return await query.ToListAsync();
    }

    public async Task CreateAsync(Supplement supplement)
    {
        await context.Supplements.AddAsync(supplement);
    }

    public void Update(Supplement supplement)
    {
        context.Supplements.Update(supplement);
    }

    public void Delete(Supplement supplement)
    {
        context.Supplements.Remove(supplement);
    }

    public async Task<int> CountAsync(
        Guid? id = null, string? brand = null, string? model = null, SupplementType? type = null, int? stock = null)
    {
        var query = context.Supplements.AsNoTracking();
        query = ApplyFilters(query, id, brand, model, type, stock);

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, string? brand = null, string? model = null, SupplementType? type = null, int? stock = null)
    {
        var count = await CountAsync(id, brand, model, type, stock);

        return count > 0;
    }

    private static IQueryable<Supplement> ApplyFilters(
        IQueryable<Supplement> query,
        Guid? id = null,
        string? brand = null,
        string? model = null,
        SupplementType? type = null,
        int? stock = null)
    {
        if (id is not null)
            query = query.Where(s => s.Id == id);
        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(s => s.Brand.Contains(brand));
        if (!string.IsNullOrWhiteSpace(model))
            query = query.Where(s => s.Model.Contains(model));
        if (type is not null)
            query = query.Where(s => s.Type == type);
        if (stock is not null)
            query = query.Where(s => s.QuantityInStock == stock);
        return query;
    }

    private static IQueryable<Supplement> ApplyOrdering(
        IQueryable<Supplement> query,
        string? orderByBrand = null,
        string? orderByModel = null,
        string? orderByType = null,
        string? orderByStock = null)
    {
        if (!string.IsNullOrWhiteSpace(orderByBrand))
            query = orderByBrand.ToLower() == "desc" 
                ? query.OrderByDescending(s => s.Brand) : query.OrderBy(s => s.Brand);
        if (!string.IsNullOrWhiteSpace(orderByModel))
            query = orderByModel.ToLower() == "desc" 
                ? query.OrderByDescending(s => s.Model) : query.OrderBy(s => s.Model);
        if (!string.IsNullOrWhiteSpace(orderByType))
            query = orderByType.ToLower() == "desc" 
                ? query.OrderByDescending(s => s.Type) : query.OrderBy(s => s.Type);
        if (!string.IsNullOrWhiteSpace(orderByStock))
            query = orderByStock.ToLower() == "desc" 
                ? query.OrderByDescending(s => s.QuantityInStock) : query.OrderBy(s => s.QuantityInStock);
        return query;
    }
}
