using ITControl.Domain.Departments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Departments.Requests;

public record FindOneDepartmentsRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator FindOneDepartmentsRepositoryParams(FindOneDepartmentsRequest request) =>
        new FindOneDepartmentsRepositoryParams
        {
            Id = request.Id,
        };
}