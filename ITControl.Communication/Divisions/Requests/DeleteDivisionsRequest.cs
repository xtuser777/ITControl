using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Divisions.Requests;

public record DeleteDivisionsRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator FindOneDivisionsRequest(DeleteDivisionsRequest request)
        => new FindOneDivisionsRequest
        {
            Id = request.Id
        };
}