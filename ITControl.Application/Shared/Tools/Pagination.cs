using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Shared.Tools;

public abstract class Pagination
{
    public static PaginationResponse Build(string page, string size, int count)
    {
        var pageInt = int.Parse(page);
        var sizeInt = int.Parse(size);
        var pages = (decimal)count / (decimal)sizeInt;
        var totalPages = Math.Ceiling(pages);

        var pagination = new PaginationResponse()
        {
            Page = pageInt,
            RecordsPerPage = sizeInt,
            TotalPages = (int)totalPages,
            TotalRecords = count
        };
        
        return pagination;
    }


    public static PaginationResponse? Build(int? page, int? size, int count)
    {
        if (!page.HasValue || !size.HasValue)
            return null;
        var pages = (decimal)count / (decimal)size!;
        var totalPages = Math.Ceiling(pages);
        if (page < 1 || page > totalPages || size == 0)
            return null;

        var pagination = new PaginationResponse()
        {
            Page = page ?? 0,
            RecordsPerPage = size ?? 0,
            TotalPages = (int)totalPages,
            TotalRecords = count
        };

        return pagination;
    }
}