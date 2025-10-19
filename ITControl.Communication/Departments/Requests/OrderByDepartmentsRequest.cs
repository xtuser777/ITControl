using ITControl.Domain.Departments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Departments.Requests;

public record OrderByDepartmentsRequest
{
    [FromHeader(Name = "X-Order-By-Alias")]
    public string? Alias { get; set; } = null;
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; } = null;

    public static implicit operator OrderByDepartmentsRepositoryParams(
        OrderByDepartmentsRequest request)
    {
        return new OrderByDepartmentsRepositoryParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }
}