using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Shared.Attributes;

public class DepartmentConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is not Guid departmentId || departmentId == Guid.Empty)
            return ValidationResult.Success;
        var departmentsRepository = 
            (IDepartmentsRepository)context.GetService(typeof(IDepartmentsRepository))!;
        var exists = departmentsRepository.ExistsAsync(
            new ExistsDepartmentsRepositoryParams { Id = departmentId }).GetAwaiter().GetResult();
        return !exists ? new ValidationResult(
            string.Format(
                Errors.ConnectionNotFound, context.DisplayName, departmentId)) 
            : ValidationResult.Success;
    }
}
