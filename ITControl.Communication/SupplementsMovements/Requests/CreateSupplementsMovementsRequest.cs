using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.SupplementsMovements.Messages;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Supplements.Interfaces;
using ITControl.Domain.Units.Interfaces;
using ITControl.Domain.Users.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.SupplementsMovements.Requests;

public class CreateSupplementsMovementsRequest
{
    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = "quantidade")]
    public int Quantity { get; set; }

    [RequiredField]
    [DateOnlyConverter]
    [DateValue]
    [DatePresentPast]
    [Display(Name = "data do movimento")]
    public DateOnly MovementDate { get; set; }

    [StringMaxLength(255)]
    [Display(Name = "observação")]
    public string Observation { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateSupplementsMovementsRequest), nameof(ValidateSupplementId))]
    [Display(Name = "suplemento")]
    public Guid SupplementId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateSupplementsMovementsRequest), nameof(ValidateUserId))]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateSupplementsMovementsRequest), nameof(ValidateUnitId))]
    [Display(Name = "unidade")]
    public Guid UnitId { get; set; }

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateSupplementsMovementsRequest), nameof(ValidateDepartmentId))]
    [Display(Name = "secretaria")]
    public Guid DepartmentId { get; set; }

    [RequiredField]
    [GuidNullableConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateSupplementsMovementsRequest), nameof(ValidateDivisionId))]
    [Display(Name = "divisão")]
    public Guid? DivisionId { get; set; }

    public static ValidationResult? ValidateQuantity(int quantity, ValidationContext context)
    {
        var instance = (CreateSupplementsMovementsRequest)context.ObjectInstance;
        var supplementsRepository = (ISupplementsRepository)context.GetService(typeof(ISupplementsRepository))!;
        var supplement = supplementsRepository.FindOneAsync(instance.SupplementId).Result;
        if (supplement != null && quantity > supplement.QuantityInStock)
        {
            return new ValidationResult(string.Format(Errors.QuantityOverStock, context.DisplayName, quantity, supplement.QuantityInStock));
        }
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateSupplementId(Guid supplementId, ValidationContext validationContext)
    {
        if (supplementId == Guid.Empty)
            return ValidationResult.Success;
        var supplementsRepository = (ISupplementsRepository)validationContext.GetService(typeof(ISupplementsRepository))!;
        var exists = supplementsRepository.ExistsAsync(id: supplementId).Result;
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.SupplementNotFound, supplementId));
        }
        else
        {
            return ValidationResult.Success;
        }
    }

    public static ValidationResult? ValidateUserId(Guid userId, ValidationContext validationContext)
    {
        if (userId == Guid.Empty)
            return ValidationResult.Success;
        var usersRepository = (IUsersRepository)validationContext.GetService(typeof(IUsersRepository))!;
        var exists = usersRepository.ExistsAsync(id: userId).Result;
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.UserNotFound, userId));
        }
        else
        {
            return ValidationResult.Success;
        }
    }

    public static ValidationResult? ValidateUnitId(Guid unitId, ValidationContext validationContext)
    {
        if (unitId == Guid.Empty)
            return ValidationResult.Success;
        var unitsRepository = (IUnitsRepository)validationContext.GetService(typeof(IUnitsRepository))!;
        var exists = unitsRepository.ExistsAsync(id: unitId).Result;
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.UnitNotFound, unitId));
        }
        else
        {
            return ValidationResult.Success;
        }
    }

    public static ValidationResult? ValidateDepartmentId(Guid departmentId, ValidationContext validationContext)
    {
        if (departmentId == Guid.Empty)
            return ValidationResult.Success;
        var departmentsRepository = (IDepartmentsRepository)validationContext.GetService(typeof(IDepartmentsRepository))!;
        var exists = departmentsRepository.ExistsAsync(id: departmentId).Result;
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.DepartmentNotFound, departmentId));
        }
        else
        {
            return ValidationResult.Success;
        }
    }

    public static ValidationResult? ValidateDivisionId(Guid? divisionId, ValidationContext validationContext)
    {
        if (!divisionId.HasValue) return ValidationResult.Success;
        if (divisionId == Guid.Empty) return ValidationResult.Success;
        var divisionsRepository = (IDivisionsRepository)validationContext.GetService(typeof(IDivisionsRepository))!;
        var exists = divisionsRepository.ExistsAsync(id: divisionId.Value).Result;
        if (!exists)
        {
            return new ValidationResult(string.Format(Errors.DivisionNotFound, divisionId));
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
