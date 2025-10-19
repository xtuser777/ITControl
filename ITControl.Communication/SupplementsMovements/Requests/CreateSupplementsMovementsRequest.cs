using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Communication.SupplementsMovements.Resources;
using ITControl.Domain.Supplements.Interfaces;

namespace ITControl.Communication.SupplementsMovements.Requests;

public class CreateSupplementsMovementsRequest
{
    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = nameof(Quantity), ResourceType = typeof(DisplayNames))]
    public int Quantity { get; set; }

    [RequiredField]
    [DateValue]
    [DatePresentPast]
    [Display(Name = nameof(MovementDate), ResourceType = typeof(DisplayNames))]
    public DateOnly MovementDate { get; set; }

    [StringMaxLength(255)]
    [Display(Name = nameof(Observation), ResourceType = typeof(DisplayNames))]
    public string Observation { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [SupplementConnection]
    [Display(Name = nameof(SupplementId), ResourceType = typeof(DisplayNames))]
    public Guid SupplementId { get; set; }

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }

    [RequiredField]
    [GuidValue]
    [UnitConnection]
    [Display(Name = nameof(UnitId), ResourceType = typeof(DisplayNames))]
    public Guid UnitId { get; set; }

    [RequiredField]
    [GuidValue]
    [DepartmentConnection]
    [Display(Name = nameof(DepartmentId), ResourceType = typeof(DisplayNames))]
    public Guid DepartmentId { get; set; }

    [RequiredField]
    [GuidValue]
    [DivisionConnection]
    [Display(Name = nameof(DivisionId), ResourceType = typeof(DisplayNames))]
    public Guid? DivisionId { get; set; }

    public static ValidationResult? ValidateQuantity(int quantity, ValidationContext context)
    {
        var instance = (CreateSupplementsMovementsRequest)context.ObjectInstance;
        var supplementsRepository = (ISupplementsRepository)context.GetService(typeof(ISupplementsRepository))!;
        var supplement = supplementsRepository.FindOneAsync(instance.SupplementId).GetAwaiter().GetResult();
        if (supplement != null && quantity > supplement.QuantityInStock)
        {
            return new ValidationResult(string.Format(Errors.QuantityOverStock, context.DisplayName, quantity, supplement.QuantityInStock));
        }
        return ValidationResult.Success;
    }
}
