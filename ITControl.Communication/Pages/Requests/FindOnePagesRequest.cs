using ITControl.Domain.Pages.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Pages.Requests;

public record FindOnePagesRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator FindOnePagesRepositoryParams(FindOnePagesRequest request) =>
        new()
        {
            Id = request.Id,
        };
}
