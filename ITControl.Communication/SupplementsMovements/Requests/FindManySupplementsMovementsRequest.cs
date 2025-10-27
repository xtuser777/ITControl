using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Communication.SupplementsMovements.Requests;

public record FindManySupplementsMovementsRequest : PageableRequest
{
    public int? Quantity { get; set; }
    public DateOnly? MovementDate { get; set; }
    public string? Observation { get; set; }
    public Guid? SupplementId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }

    public static implicit operator FindManySupplementsMovementsParams(
        FindManySupplementsMovementsRequest request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplementId = request.SupplementId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId,
        };

    public static implicit operator CountSupplementsMovementsParams(
        FindManySupplementsMovementsRequest request)
        => new()
        {
            Quantity = request.Quantity,
            MovementDate = request.MovementDate,
            Observation = request.Observation,
            SupplementId = request.SupplementId,
            UserId = request.UserId,
            UnitId = request.UnitId,
            DepartmentId = request.DepartmentId,
            DivisionId = request.DivisionId,
        };

    public static implicit operator PaginationParams(
        FindManySupplementsMovementsRequest request)
        => new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}
