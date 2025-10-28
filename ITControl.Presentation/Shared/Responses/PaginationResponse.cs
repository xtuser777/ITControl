namespace ITControl.Presentation.Shared.Responses;

public class PaginationResponse
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public int RecordsPerPage { get; set; }
}