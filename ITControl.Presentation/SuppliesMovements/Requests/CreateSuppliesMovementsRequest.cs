using ITControl.Domain.Shared.Params;
using ITControl.Domain.Supplies.Interfaces;
using ITControl.Domain.SuppliesMovements.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using System.ComponentModel.DataAnnotations;
using Errors = ITControl.Domain.Shared.Messages.Errors;

namespace ITControl.Presentation.SuppliesMovements.Requests;

public class CreateSuppliesMovementsRequest
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
    [SupplyConnection]
    [Display(Name = nameof(SupplyId), ResourceType = typeof(DisplayNames))]
    public Guid SupplyId { get; set; }

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

    [GuidValue]
    [DivisionConnection]
    [Display(Name = nameof(DivisionId), ResourceType = typeof(DisplayNames))]
    public Guid? DivisionId { get; set; }

    public static ValidationResult? ValidateQuantity(
        int quantity, ValidationContext context)
    {
        var instance = 
            (CreateSuppliesMovementsRequest)context.ObjectInstance;
        var suppliesRepository = 
            (ISuppliesRepository)context
                .GetService(typeof(ISuppliesRepository))!;
        var findOneParams = new FindOneRepositoryParams() 
            { Id = instance.SupplyId };
        var supply = suppliesRepository
            .FindOneAsync(findOneParams).GetAwaiter().GetResult();
        if (supply != null && quantity > supply.QuantityInStock)
        {
            return new ValidationResult(
                string.Format(
                    Errors.QuantityOverStock, 
                    context.DisplayName, 
                    quantity, 
                    supply.QuantityInStock));
        }
        return ValidationResult.Success;
    }

    public static implicit operator SupplyMovementProps(
        CreateSuppliesMovementsRequest request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplyId = request.SupplyId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId
        };
}
