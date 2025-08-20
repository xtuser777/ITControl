using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Calls.Responses;
public class FindOneCallsStatusResponse
{
    public Guid Id { get; set; }
    public TranslatableField Status { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string UpdatedAt { get; set; } = string.Empty;
}
