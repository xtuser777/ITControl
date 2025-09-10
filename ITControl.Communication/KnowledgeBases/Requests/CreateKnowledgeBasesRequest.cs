using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Users.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.KnowledgeBases.Requests;

public class CreateKnowledgeBasesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "título")]
    public string Title { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = "conteúdo")]
    public string Content { get; set; } = string.Empty;

    [RequiredField]
    [TimeOnlyConverter]
    [TimeValue]
    [Display(Name = "tempo estimado")]
    public TimeOnly EstimatedTime { get; set; }

    [RequiredField]
    [StringMaxLength(50)]
    [CustomValidation(typeof(CreateKnowledgeBasesRequest), nameof(ValidateReason))]
    [Display(Name = "motivo")]
    public string Reason { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateKnowledgeBasesRequest), nameof(ValidateUserId))]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    public static implicit operator KnowledgeBase(CreateKnowledgeBasesRequest request) =>
        new(
            request.Title,
            request.Content,
            request.EstimatedTime,
            Enum.Parse<CallReason>(request.Reason, true),
            request.UserId
        );

    public static ValidationResult? ValidateReason(string reason, ValidationContext context)
    {
        if (Enum.TryParse<CallReason>(reason, true, out _))
        {
            return ValidationResult.Success;
        }
        var enumValues = string.Join(", ", Enum.GetNames(typeof(CallReason)));
        return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, enumValues));
    }

    public static ValidationResult? ValidateUserId(Guid userId, ValidationContext context)
    {
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
