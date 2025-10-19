using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Departments.Requests;

public record FindManyDepartmentsRequest : PageableRequest
{
    public string? Alias { get; set; } = null;
    public string? Name { get; set; } = null;

    public static implicit operator FindManyDepartmentsRepositoryParams(FindManyDepartmentsRequest request)
    {
        return new FindManyDepartmentsRepositoryParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }

    public static implicit operator CountDepartmentsRepositoryParams(FindManyDepartmentsRequest request)
    {
        return new CountDepartmentsRepositoryParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }

    public static implicit operator PaginationParams(FindManyDepartmentsRequest request) =>
        new PaginationParams()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}