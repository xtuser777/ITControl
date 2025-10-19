using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Users.Interfaces;

namespace ITControl.Communication.Shared.Attributes;

public class UserConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid userId || userId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var usersRepository = (IUsersRepository)validationContext.GetService(typeof(IUsersRepository))!;
        var exists = usersRepository.ExistsAsync(new () { Id = userId }).GetAwaiter().GetResult();
        if (!exists)
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, userId));

        return ValidationResult.Success;
    }
}
