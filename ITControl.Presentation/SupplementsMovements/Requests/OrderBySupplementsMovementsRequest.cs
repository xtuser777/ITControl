using ITControl.Domain.SupplementsMovements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Requests;

public record OrderBySupplementsMovementsRequest
{
    [FromHeader(Name = "X-Order-By-Quantity")]
    public string? Quantity { get; init; }
    
    [FromHeader(Name = "X-Order-By-MovementDate")]
    public string? MovementDate { get; init; }
    
    [FromHeader(Name = "X-Order-By-Observation")]
    public string? Observation { get; init; }
    
    [FromHeader(Name = "X-Order-By-Supplement")]
    public string? Supplement { get; init; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; init; }
    
    [FromHeader(Name = "X-Order-By-Unit")]
    public string? Unit { get; init; }
    
    [FromHeader(Name = "X-Order-By-Department")]
    public string? Department { get; init; }
    
    [FromHeader(Name = "X-Order-By-Division")]
    public string? Division { get; init; }

    public static implicit operator OrderBySupplementsMovementsParams(
        OrderBySupplementsMovementsRequest request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            Supplement = request.Supplement,
            User = request.User,
            Unit = request.Unit,
            Department = request.Department,
            Division = request.Division,
        };
}