using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Attributes;

public class RoleConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid roleId || roleId == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var roleRepository = 
            (IRolesRepository)validationContext
                .GetService(typeof(IRolesRepository))!;
        var existsParams = new ExistsRolesParams() { Id = roleId };
        var exists = roleRepository
            .ExistsAsync(existsParams).GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound, 
                    validationContext.DisplayName, roleId));
        }

        return ValidationResult.Success;
    }
}
