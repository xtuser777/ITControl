using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.KnowledgeBases.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.KnowledgeBases.Requests;

public record CreateKnowledgeBasesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Title), ResourceType = typeof(DisplayNames))]
    public string Title { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(Content), ResourceType = typeof(DisplayNames))]
    public string Content { get; set; } = string.Empty;

    [RequiredField]
    [TimeValue]
    [Display(Name = nameof(EstimatedTime), ResourceType = typeof(DisplayNames))]
    public TimeOnly EstimatedTime { get; set; }

    [RequiredField]
    [StringMaxLength(50)]
    [EnumValue(typeof(CallReason))]
    [Display(Name = nameof(Reason), ResourceType = typeof(DisplayNames))]
    public string Reason { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }

    public static implicit operator KnowledgeBaseProps(
        CreateKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Enum.Parse<CallReason>(request.Reason, true),
            UserId = request.UserId
        };
}
