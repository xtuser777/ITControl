using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Users.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.KnowledgeBases.Requests;

public class UpdateKnowledgeBasesRequest
{
    [StringMaxLength(100)]
    [Display(Name = "título")]
    public string? Title { get; set; } = string.Empty;

    [Display(Name = "conteúdo")]
    public string? Content { get; set; } = string.Empty;

    [TimeOnlyConverter]
    [TimeValue]
    [Display(Name = "tempo estimado")]
    public TimeOnly? EstimatedTime { get; set; }

    [StringMaxLength(50)]
    [CustomValidation(typeof(UpdateKnowledgeBasesRequest), nameof(ValidateReason))]
    [Display(Name = "motivo")]
    public string? Reason { get; set; } = string.Empty;

    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(UpdateKnowledgeBasesRequest), nameof(ValidateUserId))]
    [Display(Name = "usuário")]
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

    public static ValidationResult? ValidateUserId(Guid? userId, ValidationContext context)
    {
        if (userId == null) return ValidationResult.Success;
        if (userId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var repository = (IUsersRepository?)context.GetService(typeof(IUsersRepository));
        if (repository == null)
        {
            return new ValidationResult(Errors.UsersRepositoryNotAvailable);
        }
        var userExists = repository.ExistsAsync(id: userId, active: true).GetAwaiter().GetResult();
        return userExists
            ? ValidationResult.Success
            : new ValidationResult(string.Format(Errors.UserConnectionNotFound, userId));
    }
}
