using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Shared.Repositories;

public abstract class BaseRepository
{
    protected IQueryable<Entity> query = null!;

    protected void ApplyIncludes<T>(T? @params)
    {
        if (@params is null) return;
        foreach (var property in @params.GetType().GetProperties())
        {
            var value = property.GetValue(@params);
            if (value is null) continue;
            if (property.PropertyType.BaseType == typeof(object))
            {
                foreach (var subProperty in property.PropertyType.GetProperties())
                {
                    var subValue = subProperty.GetValue(property.GetValue(@params));
                    if (subValue is null) continue;
                    if (subProperty.PropertyType.BaseType == typeof(object))
                    {
                        foreach (var subSubProperty in subProperty.PropertyType.GetProperties())
                        {
                            var subSubValue = subSubProperty.GetValue(subProperty.GetValue(property.GetValue(@params)));
                            if (subSubValue is true)
                                query = query.Include($"{property.Name}.{subProperty.Name}.{subSubProperty.Name}");
                        }
                    }
                    else if (subValue is true)
                    {
                        query = query.Include($"{property.Name}.{subProperty.Name}");
                    }
                }
            }
            else if (value is true)
            {
                query = query.Include(property.Name);
            }
        }
    }

    protected void ApplyPagination(PaginationParams? @params)
    {
        if (@params is null) return;
        var (page, size) = @params;
        if (page != null && size != null)
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
    }

    protected void BuildQuery<T>(T @params)
    {
        if (@params is null) return;
        foreach (var property in @params.GetType().GetProperties())
        {
            var value = property.GetValue(@params);
            if (value is null) continue;
            query = property.PropertyType == typeof(string) 
                ? query.Where(x => EF.Property<string>(x!, property.Name).Contains((string)value)) 
                : property.Name.StartsWith("Exclude") 
                ? query.Where(x => EF.Property<object>(x!, property.Name) != value)
                : query.Where(x => EF.Property<object>(x!, property.Name) == value);
        }
    }

    protected void BuildOrderBy<T>(T @params)
    {
        if (@params is null) return;
        foreach (var property in @params.GetType().GetProperties())
        {
            if (property.GetValue(@params) is not string value) continue;
            query = value switch
            {
                "a" => query.OrderBy(p => EF.Property<object>(p!, property.Name)),
                "d" => query.OrderByDescending(p => EF.Property<object>(p!, property.Name)),
                _ => query,
            };
        }
    }
}
