using ITControl.Domain.Systems.Params;

namespace ITControl.Communication.Systems.Requests;

public record FindOneSystemsRequest
{
    public Guid Id { get; set; }
    public bool? IncludeContract { get; set; } = true;

    public static implicit operator FindOneSystemsRepositoryParams(FindOneSystemsRequest request) =>
        new()
        {
            Id = request.Id,
            IncludeContract = request.IncludeContract
        };
}
