using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Divisions.Requests;

public record FindManyDivisionsRequest : PageableRequest
{
    public string? Name { get; init; } = null;
    public Guid? DepartmentId { get; init; } = null;

    public static implicit operator FindManyDivisionsRepositoryParams(
        FindManyDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId,
        };

    public static implicit operator CountDivisionsRepositoryParams(
        FindManyDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };

    public static implicit operator PaginationParams(
        FindManyDivisionsRequest request) =>
        new ()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}