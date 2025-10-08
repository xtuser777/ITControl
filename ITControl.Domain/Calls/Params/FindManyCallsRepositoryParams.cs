using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.Calls.Params;

public class FindManyCallsRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Description { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Enums.CallStatus? Status { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public string? OrderByTitle { get; set; } = null;
    public string? OrderByDescription { get; set; } = null;
    public string? OrderByReason { get; set; } = null;
    public string? OrderByStatus { get; set; } = null;
    public string? OrderByUser { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public void Deconstruct(
        out int? page,
        out int? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountCallsRepositoryParams(FindManyCallsRepositoryParams @params) =>
        new()
        {
            Title = @params.Title,
            Description = @params.Description,
            Reason = @params.Reason,
            Status = @params.Status,
            UserId = @params.UserId
        };
}
