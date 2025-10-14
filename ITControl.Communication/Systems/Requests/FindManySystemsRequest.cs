using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Params;

namespace ITControl.Communication.Systems.Requests;

public record FindManySystemsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public string? Own { get; set; }
    public Guid? ContractId { get; set; }

    public static implicit operator FindManySystemsRepositoryParams(FindManySystemsRequest request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = Parser.ToBoolOptional(request.Own),
            ContractId = request.ContractId
        };

    public static implicit operator CountSystemsRepositoryParams(FindManySystemsRequest request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = Parser.ToBoolOptional(request.Own),
            ContractId = request.ContractId
        };

    public static implicit operator PaginationParams(FindManySystemsRequest request) =>
        new()
        {
            Size = Parser.ToIntOptional(request.Size),
            Page = Parser.ToIntOptional(request.Page)
        };
}