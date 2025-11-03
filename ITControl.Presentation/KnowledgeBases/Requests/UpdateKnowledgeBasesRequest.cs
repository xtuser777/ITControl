using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.KnowledgeBases.Props;
using ITControl.Domain.Shared.Utils;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.KnowledgeBases.Requests;

public record UpdateKnowledgeBasesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Title), ResourceType = typeof(DisplayNames))]
    public string? Title { get; set; } = string.Empty;

    [StringMinLength(1)]
    [Display(Name = nameof(Content), ResourceType = typeof(DisplayNames))]
    public string? Content { get; set; } = string.Empty;

    [TimeValue]
    [Display(Name = nameof(EstimatedTime), ResourceType = typeof(DisplayNames))]
    public TimeOnly? EstimatedTime { get; set; }

    [StringMaxLength(50)]
    [EnumValue(typeof(CallReason))]
    [Display(Name = nameof(Reason), ResourceType = typeof(DisplayNames))]
    public string? Reason { get; set; } = string.Empty;

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }

    public static implicit operator KnowledgeBaseProps(
        UpdateKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };
}
