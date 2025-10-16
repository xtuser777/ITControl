using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
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

    public KnowledgeBase(KnowledgeBaseParams @params)
    {
        Id = Guid.NewGuid();
        Title = @params.Title;
        Content = @params.Content;
        EstimatedTime = @params.EstimatedTime;
        Reason = @params.Reason;
        UserId = @params.UserId;
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
