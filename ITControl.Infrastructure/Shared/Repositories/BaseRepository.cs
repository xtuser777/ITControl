using ITControl.Domain.Shared.Params;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Shared.Repositories;

public class BaseRepository<T>
{
    protected IQueryable<T> query = null!;

    protected void ApplyPagination(PaginationParams @params)
    {
        var (page, size) = @params;
        if (page != null && size != null)
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
    }

    protected void BuildQuery<Y>(Y @params)
    {
        if (@params is null) return;
        foreach (var property in @params.GetType().GetProperties())
        {
            var value = property.GetValue(@params);
            if (value is null) continue;
            if (property.PropertyType == typeof(string))
                query = query.Where(x => EF.Property<string>(x, property.Name).Contains((string)value));
            else
                query = query.Where(x => EF.Property<object>(x, property.Name) == value);
        }
    }

    protected void BuildOrderBy<Y>(Y @params)
    {
        if (@params is null) return;
        foreach (var property in @params.GetType().GetProperties())
        {
            if (property.GetValue(@params) is not string value) continue;
            query = value switch
            {
                "a" => query.OrderBy(p => EF.Property<object>(p, property.Name)),
                "d" => query.OrderByDescending(p => EF.Property<object>(p, property.Name)),
                _ => query,
            };
        }
    }
}
