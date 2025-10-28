namespace ITControl.Domain.Shared.Entities;

public record PaginationModel
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public int RecordsPerPage { get; set; }
}