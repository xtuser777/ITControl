using ITControl.Domain.SuppliesMovements.Entities;
using ITControl.Presentation.SuppliesMovements.Interfaces;
using ITControl.Presentation.SuppliesMovements.Responses;

namespace ITControl.Presentation.SuppliesMovements.Views;

public class SuppliesMovementsView : ISuppliesMovementsView
{
    public CreateSuppliesMovementsResponse? Create(SupplyMovement? supplyMovement)
    {
        if (supplyMovement == null)
            return null;

        return new CreateSuppliesMovementsResponse()
        {
            Id = supplyMovement.Id
        };
    }

    public FindOneSuppliesMovementsResponse? FindOne(SupplyMovement? supplyMovement)
    {
        if (supplyMovement == null)
            return null;

        return new FindOneSuppliesMovementsResponse()
        {
            Id = supplyMovement.Id,
            Quantity = supplyMovement.Quantity,
            MovementDate = supplyMovement.MovementDate,
            Observation = supplyMovement.Observation,
            SupplyId = supplyMovement.SupplyId,
            UserId = supplyMovement.UserId,
            UnitId = supplyMovement.UnitId,
            DepartmentId = supplyMovement.DepartmentId,
            DivisionId = supplyMovement.DivisionId,
            Supply = supplyMovement.Supply == null 
                ? null 
                : new FindOneSuppliesMovementsSupplyResponse()
                {
                    Id = supplyMovement.Supply.Id,
                    Brand = supplyMovement.Supply.Brand,
                    Model = supplyMovement.Supply.Model,
                    Stock = supplyMovement.Supply.QuantityInStock,
                    SupplyType = supplyMovement.Supply.Type.ToString(),
                },
            User = supplyMovement.User == null
                ? null
                : new FindOneSuppliesMovementsUserResponse()
                {
                    Id = supplyMovement.User.Id,
                    Name = supplyMovement.User.Name,
                },
            Unit = supplyMovement.Unit == null
                ? null
                : new FindOneSuppliesMovementsUnitResponse()
                {
                    Id = supplyMovement.Unit.Id,
                    Name = supplyMovement.Unit.Name,
                },
            Department = supplyMovement.Department == null
                ? null
                : new FindOneSuppliesMovementsDepartmentResponse()
                {
                    Id = supplyMovement.Department.Id,
                    Alias = supplyMovement.Department.Alias,
                    Name = supplyMovement.Department.Name,
                },
            Division = supplyMovement.Division == null
                ? null
                : new FindOneSuppliesMovementsDivisionResponse()
                {
                    Id = supplyMovement.Division.Id,
                    Name = supplyMovement.Division.Name,
                }
        };
    }

    public IEnumerable<FindManySuppliesMovementsResponse> FindMany(IEnumerable<SupplyMovement>? supplyMovements)
    {
        if (supplyMovements == null)
            return [];

        return supplyMovements.Select(supplyMovement => new FindManySuppliesMovementsResponse() 
        {
            Id = supplyMovement.Id,
            Quantity = supplyMovement.Quantity,
            MovementDate = supplyMovement.MovementDate,
            Observation = supplyMovement.Observation,
            SupplyId = supplyMovement.SupplyId,
            UserId = supplyMovement.UserId,
            UnitId = supplyMovement.UnitId,
            DepartmentId = supplyMovement.DepartmentId,
            DivisionId = supplyMovement.DivisionId,
        });
    }
}
