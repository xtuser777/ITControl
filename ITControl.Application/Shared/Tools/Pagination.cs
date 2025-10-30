using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Tools;

public abstract class Pagination
{
    
    public static PaginationModel? Build(PaginationParams parameters, int count)
    {
        var (page, size) = parameters;
        if (!page.HasValue || !size.HasValue)
            return null;
        var pages = (decimal)count / (decimal)size!;
        var totalPages = pages > 0 ? Math.Ceiling(pages) : 1;
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