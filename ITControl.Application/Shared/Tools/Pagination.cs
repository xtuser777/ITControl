using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Tools;

public abstract class Pagination
{
    public static PaginationModel Build(string page, string size, int count)
    {
        var pageInt = int.Parse(page);
        var sizeInt = int.Parse(size);
        var pages = (decimal)count / (decimal)sizeInt;
        var totalPages = Math.Ceiling(pages);

        var pagination = new PaginationModel()
        {
            Page = pageInt,
            RecordsPerPage = sizeInt,
            TotalPages = (int)totalPages,
            TotalRecords = count
        };
        
        return pagination;
    }
    
    public static PaginationModel? Build(int? page, int? size, int count)
    {
        if (!page.HasValue || !size.HasValue)
            return null;
        var pages = (decimal)count / (decimal)size!;
        var totalPages = Math.Ceiling(pages);
        if (page < 1 || page > totalPages || size == 0)
            return null;

        var pagination = new PaginationModel()
        {
            Page = page ?? 0,
            RecordsPerPage = size ?? 0,
            TotalPages = (int)totalPages,
            TotalRecords = count
        };

        return pagination;
    }
    
    public static PaginationModel? Build(PaginationParams parameters, int count)
    {
        var (page, size) = parameters;
        if (!page.HasValue || !size.HasValue)
            return null;
        var pages = (decimal)count / (decimal)size!;
        var totalPages = Math.Ceiling(pages);
        if (page < 1 || page > totalPages || size == 0)
            return null;

        var pagination = new PaginationModel()
        {
            Page = page ?? 0,
            RecordsPerPage = size ?? 0,
            TotalPages = (int)totalPages,
            TotalRecords = count
        };

        return pagination;
    }
}