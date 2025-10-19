using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Shared.Utils;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record UpdateKnowledgeBasesRequest
{
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
    [CustomValidation(typeof(UpdateKnowledgeBasesRequest), nameof(ValidateReason))]
    [Display(Name = nameof(Reason), ResourceType = typeof(DisplayNames))]
    public string? Reason { get; set; } = string.Empty;

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }

    public static implicit operator UpdateKnowledgeBaseParams(UpdateKnowledgeBasesRequest request) =>
        new()
        {
            Title = string.IsNullOrWhiteSpace(request.Title) ? null : request.Title,
            Content = string.IsNullOrWhiteSpace(request.Content) ? null : request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };

    public static ValidationResult? ValidateReason(string? reason, ValidationContext context)
    {
        if (reason == null) return ValidationResult.Success;
        if (Enum.TryParse<CallReason>(reason, true, out _))
        {
            return ValidationResult.Success;
        }
        var enumValues = string.Join(", ", Enum.GetNames(typeof(CallReason)));
        return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, enumValues));
    }
}
