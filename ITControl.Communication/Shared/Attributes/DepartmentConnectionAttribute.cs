using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Shared.Attributes;

public class DepartmentConnectionAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Guid departmentId || departmentId == Guid.Empty)
            return ValidationResult.Success;
        var departmentsRepository = (IDepartmentsRepository)validationContext.GetService(typeof(IDepartmentsRepository))!;
        var exists = departmentsRepository.ExistsAsync(id: departmentId).GetAwaiter().GetResult();
        if (!exists)
            return new ValidationResult(string.Format(Errors.ConnectionNotFound, validationContext.DisplayName, departmentId));

        return ValidationResult.Success;
    }
}
