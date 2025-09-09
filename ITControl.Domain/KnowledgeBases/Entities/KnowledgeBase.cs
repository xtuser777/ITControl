using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.KnowledgeBases.Entities;

public sealed class KnowledgeBase : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public TimeOnly EstimatedTime { get; set; }
    public CallReason Reason { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public KnowledgeBase()
    {
    }

    public KnowledgeBase(
        string title,
        string content,
        TimeOnly estimatedTime,
        CallReason reason,
        Guid userId
    )
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        EstimatedTime = estimatedTime;
        Reason = reason;
        UserId = userId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        string? title = null,
        string? content = null,
        TimeOnly? estimatedTime = null,
        CallReason? reason = null,
        Guid? userId = null
    )
    {
        Title = title ?? Title;
        Content = content ?? Content;
        EstimatedTime = estimatedTime ?? EstimatedTime;
        Reason = reason ?? Reason;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}
