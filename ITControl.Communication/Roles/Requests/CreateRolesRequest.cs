using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Messages;
namespace ITControl.Communication.Roles.Requests;

public record CreateRolesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [CustomValidation(typeof(CreateRolesRequest), nameof(ValidateName))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];

    public static implicit operator RoleParams(CreateRolesRequest request) => new()
    {
        Name = request.Name,
        Active = true
    };

    public static ValidationResult? ValidateName(string name, ValidationContext context)
    {
        var rolesRepository = 
            (IRolesRepository?)context.GetService(typeof(IRolesRepository))!;
        var exists = rolesRepository
            .ExistsAsync(new ExistsRolesRepositoryParams { Name = name })
            .GetAwaiter()
            .GetResult();
        if (exists)
            return new ValidationResult(string.Format(Errors.UniqueField, DisplayNames.Name));
        return ValidationResult.Success;
    }
}