using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Presentation.SupplementsMovements.Interfaces;
using ITControl.Presentation.SupplementsMovements.Responses;

namespace ITControl.Presentation.SupplementsMovements.Views;

public class SupplementsMovementsView : ISupplementsMovementsView
{
    public CreateSupplementsMovementsResponse? Create(SupplementMovement? supplementMovement)
    {
        if (supplementMovement == null)
            return null;

        return new CreateSupplementsMovementsResponse()
        {
            Id = supplementMovement.Id
        };
    }

    public FindOneSupplementsMovementsResponse? FindOne(SupplementMovement? supplementMovement)
    {
        if (supplementMovement == null)
            return null;

        return new FindOneSupplementsMovementsResponse()
        {
            Id = supplementMovement.Id,
            Quantity = supplementMovement.Quantity,
            MovementDate = supplementMovement.MovementDate,
            Observation = supplementMovement.Observation,
            SupplementId = supplementMovement.SupplementId,
            UserId = supplementMovement.UserId,
            UnitId = supplementMovement.UnitId,
            DepartmentId = supplementMovement.DepartmentId,
            DivisionId = supplementMovement.DivisionId,
            Supplement = supplementMovement.Supplement == null 
                ? null 
                : new FindOneSupplementsMovementsSupplementResponse()
                {
                    Id = supplementMovement.Supplement.Id,
                    Brand = supplementMovement.Supplement.Brand,
                    Model = supplementMovement.Supplement.Model,
                    Stock = supplementMovement.Supplement.QuantityInStock,
                    SupplementType = supplementMovement.Supplement.Type.ToString(),
                },
            User = supplementMovement.User == null
                ? null
                : new FindOneSupplementsMovementsUserResponse()
                {
                    Id = supplementMovement.User.Id,
                    Name = supplementMovement.User.Name,
                },
            Unit = supplementMovement.Unit == null
                ? null
                : new FindOneSupplementsMovementsUnitResponse()
                {
                    Id = supplementMovement.Unit.Id,
                    Name = supplementMovement.Unit.Name,
                },
            Department = supplementMovement.Department == null
                ? null
                : new FindOneSupplementsMovementsDepartmentResponse()
                {
                    Id = supplementMovement.Department.Id,
                    Alias = supplementMovement.Department.Alias,
                    Name = supplementMovement.Department.Name,
                },
            Division = supplementMovement.Division == null
                ? null
                : new FindOneSupplementsMovementsDivisionResponse()
                {
                    Id = supplementMovement.Division.Id,
                    Name = supplementMovement.Division.Name,
                }
        };
    }

    public IEnumerable<FindManySupplementsMovementsResponse> FindMany(IEnumerable<SupplementMovement>? supplementMovements)
    {
        if (supplementMovements == null)
            return [];

        return supplementMovements.Select(supplementMovement => new FindManySupplementsMovementsResponse() 
        {
            Id = supplementMovement.Id,
            Quantity = supplementMovement.Quantity,
            MovementDate = supplementMovement.MovementDate,
            Observation = supplementMovement.Observation,
            SupplementId = supplementMovement.SupplementId,
            UserId = supplementMovement.UserId,
            UnitId = supplementMovement.UnitId,
            DepartmentId = supplementMovement.DepartmentId,
            DivisionId = supplementMovement.DivisionId,
        });
    }
}
