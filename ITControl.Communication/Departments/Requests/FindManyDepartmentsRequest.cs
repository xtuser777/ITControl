using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Departments.Params;

namespace ITControl.Communication.Departments.Requests;

public record FindManyDepartmentsRequest : FindManyRequest
{
    public string? Alias { get; set; } = null;
    public string? Name { get; set; } = null;

    public static implicit operator FindManyDepartmentsParams(
        FindManyDepartmentsRequest request)
    {
        return new FindManyDepartmentsParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }

    public static implicit operator CountDepartmentsParams(
        FindManyDepartmentsRequest request)
    {
        return new CountDepartmentsParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }
}