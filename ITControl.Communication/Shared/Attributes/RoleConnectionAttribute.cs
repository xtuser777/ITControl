using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Attributes;

public class RoleConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid roleId || roleId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var roleRepository = (IRolesRepository)validationContext.GetService(typeof(IRolesRepository))!;
        var exists = roleRepository.ExistsAsync(new() { Id = roleId }).GetAwaiter().GetResult();
        if (exists == false)
        {
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, roleId));
        }

        return ValidationResult.Success;
    }
}
