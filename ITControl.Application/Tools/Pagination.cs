using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Tools;

public class Pagination
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
}