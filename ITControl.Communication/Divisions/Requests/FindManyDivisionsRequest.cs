using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Divisions.Params;

namespace ITControl.Communication.Divisions.Requests;

public class FindManyDivisionsRequest : PageableRequest
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByDepartment { get; set; }

    public static implicit operator FindManyDivisionsRepositoryParams(FindManyDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId,
            OrderByName = request.OrderByName,
            OrderByDepartment = request.OrderByDepartment,
            Page = request.Page != null ? int.Parse(request.Page) : null,
            Size = request.Size != null ? int.Parse(request.Size) : null
        };
}