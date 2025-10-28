using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Calls.Responses;
public class FindOneCallsStatusResponse
{
    public Guid Id { get; set; }
    public TranslatableField Status { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
