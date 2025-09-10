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

    public void Update(UpdateKnowledgeBaseParams @params)
    {
        var (title, content, estimatedTime, reason, userId) = @params;
        Title = title ?? Title;
        Content = content ?? Content;
        EstimatedTime = estimatedTime ?? EstimatedTime;
        Reason = reason ?? Reason;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}

public class UpdateKnowledgeBaseParams
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public TimeOnly? EstimatedTime { get; set; }
    public CallReason? Reason { get; set; }
    public Guid? UserId { get; set; }

    internal void Deconstruct(
        out string? title,
        out string? content,
        out TimeOnly? estimatedTime,
        out CallReason? reason,
        out Guid? userId
    )
    {
        title = Title;
        content = Content;
        estimatedTime = EstimatedTime;
        reason = Reason;
        userId = UserId;
    }
}
