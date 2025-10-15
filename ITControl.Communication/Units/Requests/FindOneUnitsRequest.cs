using ITControl.Domain.Units.Params;

namespace ITControl.Communication.Units.Requests;

public record FindOneUnitsRequest
{
    public Guid Id { get; set; }

    public static implicit operator FindOneUnitsRepositoryParams(FindOneUnitsRequest request) => new()
    {
        Id = request.Id
    };
}
