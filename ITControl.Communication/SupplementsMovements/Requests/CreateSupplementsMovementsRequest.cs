using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Communication.SupplementsMovements.Resources;
using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Interfaces;
using ITControl.Domain.SupplementsMovements.Params;

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

    public static ValidationResult? ValidateQuantity(
        int quantity, ValidationContext context)
    {
        var instance = 
            (CreateSupplementsMovementsRequest)context.ObjectInstance;
        var supplementsRepository = 
            (ISupplementsRepository)context
                .GetService(typeof(ISupplementsRepository))!;
        var findOneParams = new FindOneRepositoryParams() 
            { Id = instance.SupplementId };
        var supplement = supplementsRepository
            .FindOneAsync(findOneParams).GetAwaiter().GetResult();
        if (supplement != null && quantity > supplement.QuantityInStock)
        {
            return new ValidationResult(
                string.Format(
                    Errors.QuantityOverStock, 
                    context.DisplayName, 
                    quantity, 
                    supplement.QuantityInStock));
        }
        return ValidationResult.Success;
    }

    public static implicit operator SupplementMovementParams(
        CreateSupplementsMovementsRequest request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplementId = request.SupplementId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId
        };
}
