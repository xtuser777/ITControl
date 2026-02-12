using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.SuppliesMovements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SuppliesMovements.Params;

public record IndexSuppliesMovementsParams : PaginationParams
{
    public int? Quantity { get; set; }
    public DateOnly? MovementDate { get; set; }
    public string? Observation { get; set; }
    public Guid? SupplyId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    
    [FromHeader(Name = "X-Order-By-Quantity")]
    public string? OrderByQuantity { get; init; }
    
    [FromHeader(Name = "X-Order-By-MovementDate")]
    public string? OrderByMovementDate { get; init; }
    
    [FromHeader(Name = "X-Order-By-Observation")]
    public string? OrderByObservation { get; init; }
    
    [FromHeader(Name = "X-Order-By-Supply")]
    public string? OrderBySupply { get; init; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? OrderByUser { get; init; }
    
    [FromHeader(Name = "X-Order-By-Unit")]
    public string? OrderByUnit { get; init; }
    
    [FromHeader(Name = "X-Order-By-Department")]
    public string? OrderByDepartment { get; init; }
    
    [FromHeader(Name = "X-Order-By-Division")]
    public string? OrderByDivision { get; init; }

    public static implicit operator OrderBySuppliesMovementsParams(
        IndexSuppliesMovementsParams request)
        => new()
        {
            Quantity = request.OrderByQuantity,
            MovementDate = request.OrderByMovementDate,
            Observation = request.OrderByObservation,
            Supply = request.OrderBySupply,
            User = request.OrderByUser,
            Unit = request.OrderByUnit,
            Department = request.OrderByDepartment,
            Division = request.OrderByDivision,
        };

    public static implicit operator FindManySuppliesMovementsParams(
        IndexSuppliesMovementsParams request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplyId = request.SupplyId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId,
        };

    public static implicit operator CountSuppliesMovementsParams(
        IndexSuppliesMovementsParams request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplyId = request.SupplyId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId,
        };

    public static implicit operator FindManyServiceParams(
        IndexSuppliesMovementsParams indexParams)
        => new()
        {
            FindManyProps = indexParams,
            OrderByParams = indexParams,
            PaginationParams = indexParams,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexSuppliesMovementsParams indexParams)
        => new()
        {
            CountProps = indexParams,
            PaginationParams = indexParams,
        };
}